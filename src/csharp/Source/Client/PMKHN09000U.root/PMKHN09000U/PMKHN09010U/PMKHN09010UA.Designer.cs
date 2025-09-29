using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Windows.Forms
{
	partial class PMKHN09010UA
	{
		private System.Windows.Forms.Panel BackGround_Panel;
		private System.Windows.Forms.Panel Container_Panel;
		private Infragistics.Win.Misc.UltraGridBagLayoutManager ultraGridBagLayoutManager1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel56;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_Kana;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_Name2;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_Name;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerSubCode;
		private Infragistics.Win.Misc.UltraLabel BusinessTypeCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel JobTypeCodeTitle_ULabel;
        private Infragistics.Win.Misc.UltraLabel CustAnalysCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel BillCollecterNmTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel CustomerAgentNmTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel CollectMoneyCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel CollectMoneyDayTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel TotalDayTitle_ULabel;
        private Infragistics.Win.Misc.UltraLabel DmOutCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel CorporateDivCodeTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel59;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode6;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode5;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode4;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode3;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode2;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustAnalysCode1;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_CollectMoneyDay;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_TotalDay;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_OutputNameCode;
		private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CollectMoneyCode;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CorporateDivCode;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_DmOutCode;
		private Infragistics.Win.Misc.UltraLabel ultraLabel61;
		private Infragistics.Win.Misc.UltraLabel ultraLabel62;
		private Infragistics.Win.Misc.UltraLabel CustomerDetails_ULabel;
		private Infragistics.Win.Misc.UltraLabel uLabel_InputModeTitle;
		private Infragistics.Win.Misc.UltraButton uButton_StyleChange;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.Misc.UltraButton uButton_ClaimNameGuide;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Timer Initialize_Timer;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerClaimTitle;
        private Infragistics.Win.Misc.UltraLabel uLabel_CustomerNameTitle;
		private Infragistics.Win.Misc.UltraLabel uLabel_CustomerDetailsTitle;
		private Infragistics.Win.Misc.UltraButton uButton_CustomerAgentNmGuide;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerAgentNm;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo4Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo2Title;
		private Infragistics.Win.Misc.UltraButton uButton_BillCollecterNmGuide;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_BillCollecterNm;
		private Broadleaf.Library.Windows.Forms.TImeControl NameToKana_TImeControl;
		private Broadleaf.Library.Windows.Forms.TAttack25 tAttack251;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel uLabel_ClaimName2;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// égópÇ≥ÇÍÇƒÇ¢ÇÈÉäÉ\Å[ÉXÇ…å„èàóùÇé¿çsÇµÇ‹Ç∑ÅB
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows ÉtÉHÅ[ÉÄ ÉfÉUÉCÉiÇ≈ê∂ê¨Ç≥ÇÍÇΩÉRÅ[Éh
		/// <summary>
		/// ÉfÉUÉCÉi ÉTÉ|Å[ÉgÇ…ïKóvÇ»ÉÅÉ\ÉbÉhÇ≈Ç∑ÅBÇ±ÇÃÉÅÉ\ÉbÉhÇÃì‡óeÇ
		/// ÉRÅ[Éh ÉGÉfÉBÉ^Ç≈ïœçXÇµÇ»Ç¢Ç≈Ç≠ÇæÇ≥Ç¢ÅB
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance335 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance336 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance291 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance292 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance293 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance294 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance295 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance300 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance299 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance298 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance297 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance301 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance302 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance303 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance282 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance310 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance307 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance311 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance316 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance306 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance312 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance305 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance313 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance304 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance309 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance308 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance275 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance276 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance274 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance273 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance315 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance314 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance339 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance340 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance341 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance342 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance343 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance344 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance345 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance346 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance347 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance216 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance319 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance320 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance351 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance352 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance353 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance348 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance349 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance350 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance159 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance265 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance321 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance322 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance323 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance324 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance170 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance171 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance175 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance176 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance177 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance178 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance179 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance180 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance329 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance330 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance332 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance234 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance205 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance281 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance206 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance326 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance327 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance328 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance325 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance264 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance266 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance278 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance267 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance268 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance279 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance269 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance280 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance333 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance334 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance337 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance338 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance296 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance207 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance277 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance208 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance235 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Layout.GridBagConstraint gridBagConstraint1 = new Infragistics.Win.Layout.GridBagConstraint();
            Infragistics.Win.Appearance appearance331 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance354 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance223 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance224 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance355 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance244 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance284 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance158 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance289 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance156 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance157 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance194 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance195 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance196 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance250 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance251 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance263 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance160 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance259 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance260 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance257 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance258 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance255 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance256 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance252 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance253 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance248 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance249 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance285 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance272 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance271 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance217 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance270 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance161 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance185 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance186 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance187 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance188 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance189 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance190 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance191 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance192 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance193 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance198 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance199 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance200 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance211 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance212 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance215 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance222 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance290 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance317 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance318 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance225 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance226 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance228 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance229 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance230 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance231 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance232 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance233 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance236 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance237 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance238 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance239 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance240 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance241 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance242 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance243 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance283 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance214 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance245 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance246 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance247 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance213 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance254 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance261 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance262 = new Infragistics.Win.Appearance();
            this.SubInfo0_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo0 = new System.Windows.Forms.Panel();
            this.ultraLabel64 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CustomerAgent = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PostNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Address1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_Address2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Address3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Address4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_AddressGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_HomeTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_HomeTelNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_OfficeTelNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_OfficeTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_MobileTelNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_OtherTelNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PortableTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_OthersTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_HomeFaxNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_HomeFaxNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_OfficeFaxNoDspName = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_OfficeFaxNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SearchTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tComboEditor_MainContactCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SubInfo2_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo2 = new System.Windows.Forms.Panel();
            this.tEdit_Note9 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note4Guide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_Note9Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Note4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note8Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_Note8 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note3Guide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_Note8Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Note3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note7Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_Note7 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note2Guide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_Note7Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Note2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note6Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_Note6 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_Note2Title = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Note1Guide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_Note6Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Note1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_Note1Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Note5Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Note4Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Note3Title = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Note10Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_Note10 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note5Guide = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_Note10Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Note5 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note9Guide = new Infragistics.Win.Misc.UltraButton();
            this.SubInfo4_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo4 = new System.Windows.Forms.Panel();
            this.rButton_MainSendMailAddrCd1 = new System.Windows.Forms.RadioButton();
            this.rButton_MainSendMailAddrCd0 = new System.Windows.Forms.RadioButton();
            this.tComboEditor_MailAddrKindCode2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_MailAddrKindCode1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_MailSendCode2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_MailSendCode1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tEdit_MailAddress2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_MailAddress1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SubInfo5_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo5 = new System.Windows.Forms.Panel();
            this.tEdit_AccountNoInfo3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_AccountNoInfo2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_AccountNoInfo1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.SubInfo6_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo6 = new System.Windows.Forms.Panel();
            this.tComboEditor_SlipTtlBillOutputDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_DetailBillOutputCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_TotalBillOutputDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.UOESlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.EstimatePrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ShipmSlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AcpOdrrSlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SalesSlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_UOESlipPrtDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_EstimatePrtDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_ShipmSlipPrtDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_AcpOdrrSlipPrtDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SalesSlipPrtDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel63 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_QrcodePrtCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_ReceiptOutputCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ReceiptOutputCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DmOutCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_DmOutCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_CustSlipNoMngCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CustomerSlipNoDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SubInfo7_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo7 = new System.Windows.Forms.Panel();
            this.tEdit_SimplInqAcntAcntGrId = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel65 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CustomerSecCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tComboEditor_OnlineKindDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CustomerEpCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.SubInfo8_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.panel_SubInfo8 = new System.Windows.Forms.Panel();
            this.check_CustomerInfoGuideDisp = new System.Windows.Forms.CheckBox();
            this.memo_richTextBox = new System.Windows.Forms.RichTextBox();
            this.SubInfo1_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.BackGround_Panel = new System.Windows.Forms.Panel();
            this.Container_Panel = new System.Windows.Forms.Panel();
            this.tEdit_JobTypeName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_JobTypeCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SalesAreaNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_SalesAreaCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_BusinessTypeNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_BusinessTypeCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_HonorificTitle = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_SubInfo8Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubInfo7Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubInfo6Title = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CustWarehouseCd = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_CustWarehouseGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel50 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CarMngDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel49 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_ClaimSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_ClaimSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubInfo0Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubInfo5Title = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_SubInfo4Title = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CorporateDivCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CorporateDivCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustAnalysCode1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.CustAnalysCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CustomerAttributeDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_SubInfo2Title = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustAnalysCode2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustAnalysCode4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel60 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustAnalysCode6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_NTimeCalcStDate = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_CustAnalysCode3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustAnalysCode5 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uLabel_ClaimName1 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_MngSectionNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MngSectionNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_OldCustomerAgentNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_ClaimCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel55 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SalesCnsTaxFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesMoneyFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesUnPrcFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SalesCnsTaxFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesMoneyFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesUnPrcFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel54 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CustCTaXLayRefCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel53 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ClaimSnm = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CustomerDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel51 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel48 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_TransStopDate = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel45 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_CustAgentChgDate = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_AccRecDivCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_DepoDelCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_CreditMngCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uButton_OldCustomerAgentNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CollectSight = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CollectCond = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CustomerSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_ConsTaxLayMethod = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.tDateEdit_UpdateDateTime = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.tDateEdit_CreateDateTime = new Broadleaf.Library.Windows.Forms.TDateEdit2();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerKindTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_ClaimName2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_StyleChange = new Infragistics.Win.Misc.UltraButton();
            this.uLabel_InputModeTitle = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_CollectMoneyCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_OutputNameCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_CustomerClaimTitle = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_ClaimNameGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel59 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_CustomerNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.SubInfo_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.SubInfo_UTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.uButton_BillCollecterNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_CustomerAgentNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_BillCollecterNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_CustomerAgentNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BillCollecterNmTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerAgentNmTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CollectMoneyDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CollectMoneyCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.CollectMoneyDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_TotalDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TotalDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel56 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_Kana = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Name2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_Name = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_CustomerSubCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uLabel_CustomerDetailsTitle = new Infragistics.Win.Misc.UltraLabel();
            this.BusinessTypeCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.JobTypeCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel61 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel62 = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerDetails_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGridBagLayoutManager1 = new Infragistics.Win.Misc.UltraGridBagLayoutManager(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Initialize_Timer = new System.Windows.Forms.Timer(this.components);
            this.NameToKana_TImeControl = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tAttack251 = new Broadleaf.Library.Windows.Forms.TAttack25(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.SubInfo0_UTabPageControl.SuspendLayout();
            this.panel_SubInfo0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PostNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_Address2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HomeTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OfficeTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PortableTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OthersTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HomeFaxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OfficeFaxNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SearchTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MainContactCode)).BeginInit();
            this.SubInfo2_UTabPageControl.SuspendLayout();
            this.panel_SubInfo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note5)).BeginInit();
            this.SubInfo4_UTabPageControl.SuspendLayout();
            this.panel_SubInfo4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailAddrKindCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailAddrKindCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailSendCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailSendCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MailAddress2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MailAddress1)).BeginInit();
            this.SubInfo5_UTabPageControl.SuspendLayout();
            this.panel_SubInfo5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo1)).BeginInit();
            this.SubInfo6_UTabPageControl.SuspendLayout();
            this.panel_SubInfo6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SlipTtlBillOutputDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DetailBillOutputCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TotalBillOutputDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_UOESlipPrtDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_EstimatePrtDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ShipmSlipPrtDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AcpOdrrSlipPrtDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipPrtDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_QrcodePrtCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ReceiptOutputCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DmOutCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustSlipNoMngCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerSlipNoDiv)).BeginInit();
            this.SubInfo7_UTabPageControl.SuspendLayout();
            this.panel_SubInfo7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SimplInqAcntAcntGrId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OnlineKindDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerEpCode)).BeginInit();
            this.SubInfo8_UTabPageControl.SuspendLayout();
            this.panel_SubInfo8.SuspendLayout();
            this.BackGround_Panel.SuspendLayout();
            this.Container_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_JobTypeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesAreaNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BusinessTypeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HonorificTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustWarehouseCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CarMngDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ClaimSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CorporateDivCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerAttributeDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldCustomerAgentNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCnsTaxFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesMoneyFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesUnPrcFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustCTaXLayRefCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AccRecDivCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DepoDelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CreditMngCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CollectSight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CollectCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ConsTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CollectMoneyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputNameCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).BeginInit();
            this.SubInfo_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BillCollecterNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerAgentNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CollectMoneyDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Kana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Name2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSubCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubInfo0_UTabPageControl
            // 
            this.SubInfo0_UTabPageControl.Controls.Add(this.panel_SubInfo0);
            this.SubInfo0_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo0_UTabPageControl.Name = "SubInfo0_UTabPageControl";
            this.SubInfo0_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo0
            // 
            this.panel_SubInfo0.Controls.Add(this.ultraLabel64);
            this.panel_SubInfo0.Controls.Add(this.tEdit_CustomerAgent);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel25);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel24);
            this.panel_SubInfo0.Controls.Add(this.tEdit_PostNo);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel14);
            this.panel_SubInfo0.Controls.Add(this.tEdit_Address1);
            this.panel_SubInfo0.Controls.Add(this.tNedit_Address2);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel9);
            this.panel_SubInfo0.Controls.Add(this.tEdit_Address3);
            this.panel_SubInfo0.Controls.Add(this.tEdit_Address4);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel3);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel2);
            this.panel_SubInfo0.Controls.Add(this.uButton_AddressGuide);
            this.panel_SubInfo0.Controls.Add(this.tEdit_HomeTelNo);
            this.panel_SubInfo0.Controls.Add(this.uLabel_HomeTelNoDspName);
            this.panel_SubInfo0.Controls.Add(this.uLabel_OfficeTelNoDspName);
            this.panel_SubInfo0.Controls.Add(this.tEdit_OfficeTelNo);
            this.panel_SubInfo0.Controls.Add(this.uLabel_MobileTelNoDspName);
            this.panel_SubInfo0.Controls.Add(this.uLabel_OtherTelNoDspName);
            this.panel_SubInfo0.Controls.Add(this.tEdit_PortableTelNo);
            this.panel_SubInfo0.Controls.Add(this.tEdit_OthersTelNo);
            this.panel_SubInfo0.Controls.Add(this.tEdit_HomeFaxNo);
            this.panel_SubInfo0.Controls.Add(this.uLabel_HomeFaxNoDspName);
            this.panel_SubInfo0.Controls.Add(this.uLabel_OfficeFaxNoDspName);
            this.panel_SubInfo0.Controls.Add(this.tEdit_OfficeFaxNo);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel5);
            this.panel_SubInfo0.Controls.Add(this.ultraLabel7);
            this.panel_SubInfo0.Controls.Add(this.tEdit_SearchTelNo);
            this.panel_SubInfo0.Controls.Add(this.tComboEditor_MainContactCode);
            this.panel_SubInfo0.Location = new System.Drawing.Point(-1, 0);
            this.panel_SubInfo0.Name = "panel_SubInfo0";
            this.panel_SubInfo0.Size = new System.Drawing.Size(1000, 152);
            this.panel_SubInfo0.TabIndex = 1129;
            // 
            // ultraLabel64
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel64.Appearance = appearance1;
            this.ultraLabel64.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel64.Location = new System.Drawing.Point(4, 121);
            this.ultraLabel64.Name = "ultraLabel64";
            this.ultraLabel64.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel64.TabIndex = 1130;
            this.ultraLabel64.Text = "ìæà”êÊíSìñé“";
            // 
            // tEdit_CustomerAgent
            // 
            appearance335.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerAgent.ActiveAppearance = appearance335;
            appearance336.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerAgent.Appearance = appearance336;
            this.tEdit_CustomerAgent.AutoSelect = true;
            this.tEdit_CustomerAgent.DataText = "";
            this.tEdit_CustomerAgent.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerAgent.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustomerAgent.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerAgent.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CustomerAgent.Location = new System.Drawing.Point(92, 121);
            this.tEdit_CustomerAgent.MaxLength = 20;
            this.tEdit_CustomerAgent.Name = "tEdit_CustomerAgent";
            this.tEdit_CustomerAgent.Size = new System.Drawing.Size(293, 22);
            this.tEdit_CustomerAgent.TabIndex = 1129;
            // 
            // ultraLabel25
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance3;
            this.ultraLabel25.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(531, 2);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(105, 22);
            this.ultraLabel25.TabIndex = 1128;
            this.ultraLabel25.Text = "ìdòbî‘çÜÅEFAX";
            // 
            // ultraLabel24
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance4;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(15, 2);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel24.TabIndex = 1127;
            this.ultraLabel24.Text = "èZÅ@èä";
            // 
            // tEdit_PostNo
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PostNo.ActiveAppearance = appearance5;
            appearance291.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_PostNo.Appearance = appearance291;
            this.tEdit_PostNo.AutoSelect = true;
            this.tEdit_PostNo.DataText = "";
            this.tEdit_PostNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PostNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_PostNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_PostNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PostNo.Location = new System.Drawing.Point(92, 25);
            this.tEdit_PostNo.MaxLength = 10;
            this.tEdit_PostNo.Name = "tEdit_PostNo";
            this.tEdit_PostNo.Size = new System.Drawing.Size(80, 22);
            this.tEdit_PostNo.TabIndex = 101;
            // 
            // ultraLabel14
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance6;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(4, 25);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel14.TabIndex = 328;
            this.ultraLabel14.Text = "óXï÷î‘çÜ";
            // 
            // tEdit_Address1
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Address1.ActiveAppearance = appearance7;
            appearance292.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Address1.Appearance = appearance292;
            this.tEdit_Address1.AutoSelect = true;
            this.tEdit_Address1.DataText = "";
            this.tEdit_Address1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Address1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Address1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Address1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Address1.Location = new System.Drawing.Point(92, 49);
            this.tEdit_Address1.MaxLength = 30;
            this.tEdit_Address1.Name = "tEdit_Address1";
            this.tEdit_Address1.Size = new System.Drawing.Size(430, 22);
            this.tEdit_Address1.TabIndex = 103;
            // 
            // tNedit_Address2
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_Address2.ActiveAppearance = appearance8;
            appearance293.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tNedit_Address2.Appearance = appearance293;
            this.tNedit_Address2.AutoSelect = true;
            this.tNedit_Address2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_Address2.DataText = "";
            this.tNedit_Address2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_Address2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_Address2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_Address2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_Address2.Location = new System.Drawing.Point(4, 73);
            this.tNedit_Address2.MaxLength = 2;
            this.tNedit_Address2.Name = "tNedit_Address2";
            this.tNedit_Address2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_Address2.Size = new System.Drawing.Size(25, 22);
            this.tNedit_Address2.TabIndex = 104;
            this.tNedit_Address2.Visible = false;
            // 
            // ultraLabel9
            // 
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance9;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(35, 73);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(32, 22);
            this.ultraLabel9.TabIndex = 324;
            this.ultraLabel9.Text = "íöñ⁄";
            this.ultraLabel9.Visible = false;
            // 
            // tEdit_Address3
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Address3.ActiveAppearance = appearance10;
            appearance294.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Address3.Appearance = appearance294;
            this.tEdit_Address3.AutoSelect = true;
            this.tEdit_Address3.DataText = "";
            this.tEdit_Address3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Address3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Address3.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Address3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Address3.Location = new System.Drawing.Point(92, 73);
            this.tEdit_Address3.MaxLength = 22;
            this.tEdit_Address3.Name = "tEdit_Address3";
            this.tEdit_Address3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Address3.TabIndex = 105;
            // 
            // tEdit_Address4
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Address4.ActiveAppearance = appearance11;
            appearance295.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Address4.Appearance = appearance295;
            this.tEdit_Address4.AutoSelect = true;
            this.tEdit_Address4.DataText = "";
            this.tEdit_Address4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Address4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Address4.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Address4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Address4.Location = new System.Drawing.Point(92, 97);
            this.tEdit_Address4.MaxLength = 30;
            this.tEdit_Address4.Name = "tEdit_Address4";
            this.tEdit_Address4.Size = new System.Drawing.Size(430, 22);
            this.tEdit_Address4.TabIndex = 106;
            // 
            // ultraLabel3
            // 
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance12;
            this.ultraLabel3.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(4, 49);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel3.TabIndex = 326;
            this.ultraLabel3.Text = "èZÅ@èä";
            // 
            // ultraLabel2
            // 
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance13;
            this.ultraLabel2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel2.Location = new System.Drawing.Point(4, 97);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel2.TabIndex = 327;
            this.ultraLabel2.Text = "ÉAÉpÅ[Égñº";
            this.ultraLabel2.Visible = false;
            // 
            // uButton_AddressGuide
            // 
            this.uButton_AddressGuide.Location = new System.Drawing.Point(174, 24);
            this.uButton_AddressGuide.Name = "uButton_AddressGuide";
            this.uButton_AddressGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_AddressGuide.TabIndex = 102;
            this.toolTip1.SetToolTip(this.uButton_AddressGuide, "èZèäÉKÉCÉh");
            this.uButton_AddressGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AddressGuide.Click += new System.EventHandler(this.uButton_AddressGuide_Click);
            // 
            // tEdit_HomeTelNo
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_HomeTelNo.ActiveAppearance = appearance14;
            appearance300.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_HomeTelNo.Appearance = appearance300;
            this.tEdit_HomeTelNo.AutoSelect = true;
            this.tEdit_HomeTelNo.DataText = "";
            this.tEdit_HomeTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_HomeTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_HomeTelNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_HomeTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_HomeTelNo.Location = new System.Drawing.Point(625, 24);
            this.tEdit_HomeTelNo.MaxLength = 16;
            this.tEdit_HomeTelNo.Name = "tEdit_HomeTelNo";
            this.tEdit_HomeTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_HomeTelNo.TabIndex = 201;
            // 
            // uLabel_HomeTelNoDspName
            // 
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.uLabel_HomeTelNoDspName.Appearance = appearance15;
            this.uLabel_HomeTelNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_HomeTelNoDspName.Location = new System.Drawing.Point(531, 24);
            this.uLabel_HomeTelNoDspName.Name = "uLabel_HomeTelNoDspName";
            this.uLabel_HomeTelNoDspName.Size = new System.Drawing.Size(88, 22);
            this.uLabel_HomeTelNoDspName.TabIndex = 337;
            this.uLabel_HomeTelNoDspName.Text = "é© ëÓ";
            // 
            // uLabel_OfficeTelNoDspName
            // 
            appearance16.TextHAlignAsString = "Center";
            appearance16.TextVAlignAsString = "Middle";
            this.uLabel_OfficeTelNoDspName.Appearance = appearance16;
            this.uLabel_OfficeTelNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_OfficeTelNoDspName.Location = new System.Drawing.Point(531, 48);
            this.uLabel_OfficeTelNoDspName.Name = "uLabel_OfficeTelNoDspName";
            this.uLabel_OfficeTelNoDspName.Size = new System.Drawing.Size(88, 22);
            this.uLabel_OfficeTelNoDspName.TabIndex = 338;
            this.uLabel_OfficeTelNoDspName.Text = "ãŒñ±êÊ";
            // 
            // tEdit_OfficeTelNo
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OfficeTelNo.ActiveAppearance = appearance17;
            appearance299.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OfficeTelNo.Appearance = appearance299;
            this.tEdit_OfficeTelNo.AutoSelect = true;
            this.tEdit_OfficeTelNo.DataText = "";
            this.tEdit_OfficeTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OfficeTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_OfficeTelNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OfficeTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OfficeTelNo.Location = new System.Drawing.Point(625, 48);
            this.tEdit_OfficeTelNo.MaxLength = 16;
            this.tEdit_OfficeTelNo.Name = "tEdit_OfficeTelNo";
            this.tEdit_OfficeTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_OfficeTelNo.TabIndex = 202;
            // 
            // uLabel_MobileTelNoDspName
            // 
            appearance18.TextHAlignAsString = "Center";
            appearance18.TextVAlignAsString = "Middle";
            this.uLabel_MobileTelNoDspName.Appearance = appearance18;
            this.uLabel_MobileTelNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_MobileTelNoDspName.Location = new System.Drawing.Point(531, 72);
            this.uLabel_MobileTelNoDspName.Name = "uLabel_MobileTelNoDspName";
            this.uLabel_MobileTelNoDspName.Size = new System.Drawing.Size(88, 22);
            this.uLabel_MobileTelNoDspName.TabIndex = 339;
            this.uLabel_MobileTelNoDspName.Text = "åg ë—";
            // 
            // uLabel_OtherTelNoDspName
            // 
            appearance19.TextHAlignAsString = "Center";
            appearance19.TextVAlignAsString = "Middle";
            this.uLabel_OtherTelNoDspName.Appearance = appearance19;
            this.uLabel_OtherTelNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_OtherTelNoDspName.Location = new System.Drawing.Point(531, 96);
            this.uLabel_OtherTelNoDspName.Name = "uLabel_OtherTelNoDspName";
            this.uLabel_OtherTelNoDspName.Size = new System.Drawing.Size(88, 22);
            this.uLabel_OtherTelNoDspName.TabIndex = 342;
            this.uLabel_OtherTelNoDspName.Text = "ëº";
            // 
            // tEdit_PortableTelNo
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PortableTelNo.ActiveAppearance = appearance20;
            appearance298.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_PortableTelNo.Appearance = appearance298;
            this.tEdit_PortableTelNo.AutoSelect = true;
            this.tEdit_PortableTelNo.DataText = "";
            this.tEdit_PortableTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PortableTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_PortableTelNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_PortableTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PortableTelNo.Location = new System.Drawing.Point(625, 72);
            this.tEdit_PortableTelNo.MaxLength = 16;
            this.tEdit_PortableTelNo.Name = "tEdit_PortableTelNo";
            this.tEdit_PortableTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_PortableTelNo.TabIndex = 203;
            // 
            // tEdit_OthersTelNo
            // 
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OthersTelNo.ActiveAppearance = appearance21;
            appearance297.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OthersTelNo.Appearance = appearance297;
            this.tEdit_OthersTelNo.AutoSelect = true;
            this.tEdit_OthersTelNo.DataText = "";
            this.tEdit_OthersTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OthersTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_OthersTelNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OthersTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OthersTelNo.Location = new System.Drawing.Point(625, 96);
            this.tEdit_OthersTelNo.MaxLength = 16;
            this.tEdit_OthersTelNo.Name = "tEdit_OthersTelNo";
            this.tEdit_OthersTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_OthersTelNo.TabIndex = 204;
            // 
            // tEdit_HomeFaxNo
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_HomeFaxNo.ActiveAppearance = appearance22;
            appearance301.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_HomeFaxNo.Appearance = appearance301;
            this.tEdit_HomeFaxNo.AutoSelect = true;
            this.tEdit_HomeFaxNo.DataText = "";
            this.tEdit_HomeFaxNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_HomeFaxNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_HomeFaxNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_HomeFaxNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_HomeFaxNo.Location = new System.Drawing.Point(839, 24);
            this.tEdit_HomeFaxNo.MaxLength = 16;
            this.tEdit_HomeFaxNo.Name = "tEdit_HomeFaxNo";
            this.tEdit_HomeFaxNo.Size = new System.Drawing.Size(128, 22);
            this.tEdit_HomeFaxNo.TabIndex = 205;
            // 
            // uLabel_HomeFaxNoDspName
            // 
            appearance23.TextHAlignAsString = "Center";
            appearance23.TextVAlignAsString = "Middle";
            this.uLabel_HomeFaxNoDspName.Appearance = appearance23;
            this.uLabel_HomeFaxNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_HomeFaxNoDspName.Location = new System.Drawing.Point(741, 25);
            this.uLabel_HomeFaxNoDspName.Name = "uLabel_HomeFaxNoDspName";
            this.uLabel_HomeFaxNoDspName.Size = new System.Drawing.Size(92, 22);
            this.uLabel_HomeFaxNoDspName.TabIndex = 340;
            this.uLabel_HomeFaxNoDspName.Text = "é© ëÓ";
            // 
            // uLabel_OfficeFaxNoDspName
            // 
            appearance24.TextHAlignAsString = "Center";
            appearance24.TextVAlignAsString = "Middle";
            this.uLabel_OfficeFaxNoDspName.Appearance = appearance24;
            this.uLabel_OfficeFaxNoDspName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_OfficeFaxNoDspName.Location = new System.Drawing.Point(741, 49);
            this.uLabel_OfficeFaxNoDspName.Name = "uLabel_OfficeFaxNoDspName";
            this.uLabel_OfficeFaxNoDspName.Size = new System.Drawing.Size(92, 22);
            this.uLabel_OfficeFaxNoDspName.TabIndex = 341;
            this.uLabel_OfficeFaxNoDspName.Text = "ãŒñ±êÊ";
            // 
            // tEdit_OfficeFaxNo
            // 
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OfficeFaxNo.ActiveAppearance = appearance25;
            appearance302.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OfficeFaxNo.Appearance = appearance302;
            this.tEdit_OfficeFaxNo.AutoSelect = true;
            this.tEdit_OfficeFaxNo.DataText = "";
            this.tEdit_OfficeFaxNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OfficeFaxNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_OfficeFaxNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OfficeFaxNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OfficeFaxNo.Location = new System.Drawing.Point(839, 48);
            this.tEdit_OfficeFaxNo.MaxLength = 16;
            this.tEdit_OfficeFaxNo.Name = "tEdit_OfficeFaxNo";
            this.tEdit_OfficeFaxNo.Size = new System.Drawing.Size(128, 22);
            this.tEdit_OfficeFaxNo.TabIndex = 206;
            // 
            // ultraLabel5
            // 
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance26;
            this.ultraLabel5.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(741, 97);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(92, 22);
            this.ultraLabel5.TabIndex = 343;
            this.ultraLabel5.Text = "éÂòAóçêÊ";
            // 
            // ultraLabel7
            // 
            appearance27.TextHAlignAsString = "Center";
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance27;
            this.ultraLabel7.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel7.Location = new System.Drawing.Point(741, 73);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(92, 22);
            this.ultraLabel7.TabIndex = 344;
            this.ultraLabel7.Text = "åüçıî‘çÜ";
            // 
            // tEdit_SearchTelNo
            // 
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SearchTelNo.ActiveAppearance = appearance28;
            appearance303.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SearchTelNo.Appearance = appearance303;
            this.tEdit_SearchTelNo.AutoSelect = true;
            this.tEdit_SearchTelNo.DataText = "";
            this.tEdit_SearchTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SearchTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SearchTelNo.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SearchTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SearchTelNo.Location = new System.Drawing.Point(839, 72);
            this.tEdit_SearchTelNo.MaxLength = 4;
            this.tEdit_SearchTelNo.Name = "tEdit_SearchTelNo";
            this.tEdit_SearchTelNo.Size = new System.Drawing.Size(39, 22);
            this.tEdit_SearchTelNo.TabIndex = 207;
            // 
            // tComboEditor_MainContactCode
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MainContactCode.ActiveAppearance = appearance29;
            appearance282.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance282.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_MainContactCode.Appearance = appearance282;
            this.tComboEditor_MainContactCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_MainContactCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MainContactCode.ItemAppearance = appearance30;
            this.tComboEditor_MainContactCode.Location = new System.Drawing.Point(839, 96);
            this.tComboEditor_MainContactCode.Name = "tComboEditor_MainContactCode";
            this.tComboEditor_MainContactCode.Size = new System.Drawing.Size(129, 22);
            this.tComboEditor_MainContactCode.TabIndex = 208;
            this.tComboEditor_MainContactCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_MainContactCode_SelectionChangeCommitted);
            // 
            // SubInfo2_UTabPageControl
            // 
            this.SubInfo2_UTabPageControl.Controls.Add(this.panel_SubInfo2);
            this.SubInfo2_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo2_UTabPageControl.Name = "SubInfo2_UTabPageControl";
            this.SubInfo2_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo2
            // 
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note9);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note4Guide);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note9Title);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note4);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note8Guide);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note8);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note3Guide);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note8Title);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note3);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note7Guide);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note7);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note2Guide);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note7Title);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note2);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note6Guide);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note6);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note2Title);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note1Guide);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note6Title);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note1);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note1Title);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note5Title);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note4Title);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note3Title);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note10Guide);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note10);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note5Guide);
            this.panel_SubInfo2.Controls.Add(this.uLabel_Note10Title);
            this.panel_SubInfo2.Controls.Add(this.tEdit_Note5);
            this.panel_SubInfo2.Controls.Add(this.uButton_Note9Guide);
            this.panel_SubInfo2.Location = new System.Drawing.Point(-1, 0);
            this.panel_SubInfo2.Name = "panel_SubInfo2";
            this.panel_SubInfo2.Size = new System.Drawing.Size(999, 150);
            this.panel_SubInfo2.TabIndex = 1110;
            // 
            // tEdit_Note9
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note9.ActiveAppearance = appearance31;
            appearance310.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note9.Appearance = appearance310;
            this.tEdit_Note9.AutoSelect = true;
            this.tEdit_Note9.AutoSize = false;
            this.tEdit_Note9.DataText = "";
            this.tEdit_Note9.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note9.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note9.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note9.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note9.Location = new System.Drawing.Point(590, 86);
            this.tEdit_Note9.MaxLength = 20;
            this.tEdit_Note9.Name = "tEdit_Note9";
            this.tEdit_Note9.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note9.TabIndex = 17;
            // 
            // uButton_Note4Guide
            // 
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note4Guide.Appearance = appearance32;
            this.uButton_Note4Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note4Guide.Location = new System.Drawing.Point(445, 85);
            this.uButton_Note4Guide.Name = "uButton_Note4Guide";
            this.uButton_Note4Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note4Guide.TabIndex = 8;
            this.uButton_Note4Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note4Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // uLabel_Note9Title
            // 
            appearance33.TextHAlignAsString = "Center";
            appearance33.TextVAlignAsString = "Middle";
            this.uLabel_Note9Title.Appearance = appearance33;
            this.uLabel_Note9Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note9Title.Location = new System.Drawing.Point(485, 86);
            this.uLabel_Note9Title.Name = "uLabel_Note9Title";
            this.uLabel_Note9Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note9Title.TabIndex = 519;
            this.uLabel_Note9Title.Text = "ìæà”êÊîıçlÇX";
            // 
            // tEdit_Note4
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note4.ActiveAppearance = appearance34;
            appearance307.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note4.Appearance = appearance307;
            this.tEdit_Note4.AutoSelect = true;
            this.tEdit_Note4.AutoSize = false;
            this.tEdit_Note4.DataText = "";
            this.tEdit_Note4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note4.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note4.Location = new System.Drawing.Point(120, 86);
            this.tEdit_Note4.MaxLength = 20;
            this.tEdit_Note4.Name = "tEdit_Note4";
            this.tEdit_Note4.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note4.TabIndex = 7;
            // 
            // uButton_Note8Guide
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note8Guide.Appearance = appearance35;
            this.uButton_Note8Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note8Guide.Location = new System.Drawing.Point(915, 59);
            this.uButton_Note8Guide.Name = "uButton_Note8Guide";
            this.uButton_Note8Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note8Guide.TabIndex = 16;
            this.uButton_Note8Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note8Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // tEdit_Note8
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note8.ActiveAppearance = appearance36;
            appearance311.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note8.Appearance = appearance311;
            this.tEdit_Note8.AutoSelect = true;
            this.tEdit_Note8.AutoSize = false;
            this.tEdit_Note8.DataText = "";
            this.tEdit_Note8.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note8.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note8.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note8.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note8.Location = new System.Drawing.Point(590, 60);
            this.tEdit_Note8.MaxLength = 20;
            this.tEdit_Note8.Name = "tEdit_Note8";
            this.tEdit_Note8.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note8.TabIndex = 15;
            // 
            // uButton_Note3Guide
            // 
            appearance316.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance316.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note3Guide.Appearance = appearance316;
            this.uButton_Note3Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note3Guide.Location = new System.Drawing.Point(445, 59);
            this.uButton_Note3Guide.Name = "uButton_Note3Guide";
            this.uButton_Note3Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note3Guide.TabIndex = 6;
            this.uButton_Note3Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note3Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // uLabel_Note8Title
            // 
            appearance38.TextHAlignAsString = "Center";
            appearance38.TextVAlignAsString = "Middle";
            this.uLabel_Note8Title.Appearance = appearance38;
            this.uLabel_Note8Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note8Title.Location = new System.Drawing.Point(485, 60);
            this.uLabel_Note8Title.Name = "uLabel_Note8Title";
            this.uLabel_Note8Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note8Title.TabIndex = 514;
            this.uLabel_Note8Title.Text = "ìæà”êÊîıçlÇW";
            // 
            // tEdit_Note3
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note3.ActiveAppearance = appearance39;
            appearance306.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note3.Appearance = appearance306;
            this.tEdit_Note3.AutoSelect = true;
            this.tEdit_Note3.AutoSize = false;
            this.tEdit_Note3.DataText = "";
            this.tEdit_Note3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note3.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note3.Location = new System.Drawing.Point(120, 60);
            this.tEdit_Note3.MaxLength = 20;
            this.tEdit_Note3.Name = "tEdit_Note3";
            this.tEdit_Note3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note3.TabIndex = 5;
            // 
            // uButton_Note7Guide
            // 
            appearance40.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance40.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note7Guide.Appearance = appearance40;
            this.uButton_Note7Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note7Guide.Location = new System.Drawing.Point(915, 33);
            this.uButton_Note7Guide.Name = "uButton_Note7Guide";
            this.uButton_Note7Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note7Guide.TabIndex = 14;
            this.uButton_Note7Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note7Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // tEdit_Note7
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note7.ActiveAppearance = appearance41;
            appearance312.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note7.Appearance = appearance312;
            this.tEdit_Note7.AutoSelect = true;
            this.tEdit_Note7.AutoSize = false;
            this.tEdit_Note7.DataText = "";
            this.tEdit_Note7.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note7.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note7.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note7.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note7.Location = new System.Drawing.Point(590, 34);
            this.tEdit_Note7.MaxLength = 20;
            this.tEdit_Note7.Name = "tEdit_Note7";
            this.tEdit_Note7.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note7.TabIndex = 13;
            // 
            // uButton_Note2Guide
            // 
            appearance42.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance42.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note2Guide.Appearance = appearance42;
            this.uButton_Note2Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note2Guide.Location = new System.Drawing.Point(445, 33);
            this.uButton_Note2Guide.Name = "uButton_Note2Guide";
            this.uButton_Note2Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note2Guide.TabIndex = 4;
            this.uButton_Note2Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note2Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // uLabel_Note7Title
            // 
            appearance43.TextHAlignAsString = "Center";
            appearance43.TextVAlignAsString = "Middle";
            this.uLabel_Note7Title.Appearance = appearance43;
            this.uLabel_Note7Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note7Title.Location = new System.Drawing.Point(485, 34);
            this.uLabel_Note7Title.Name = "uLabel_Note7Title";
            this.uLabel_Note7Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note7Title.TabIndex = 509;
            this.uLabel_Note7Title.Text = "ìæà”êÊîıçlÇV";
            // 
            // tEdit_Note2
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note2.ActiveAppearance = appearance44;
            appearance305.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note2.Appearance = appearance305;
            this.tEdit_Note2.AutoSelect = true;
            this.tEdit_Note2.AutoSize = false;
            this.tEdit_Note2.DataText = "";
            this.tEdit_Note2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note2.Location = new System.Drawing.Point(120, 34);
            this.tEdit_Note2.MaxLength = 20;
            this.tEdit_Note2.Name = "tEdit_Note2";
            this.tEdit_Note2.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note2.TabIndex = 3;
            // 
            // uButton_Note6Guide
            // 
            appearance202.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance202.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note6Guide.Appearance = appearance202;
            this.uButton_Note6Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note6Guide.Location = new System.Drawing.Point(915, 7);
            this.uButton_Note6Guide.Name = "uButton_Note6Guide";
            this.uButton_Note6Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note6Guide.TabIndex = 12;
            this.uButton_Note6Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note6Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // tEdit_Note6
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note6.ActiveAppearance = appearance46;
            appearance313.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note6.Appearance = appearance313;
            this.tEdit_Note6.AutoSelect = true;
            this.tEdit_Note6.AutoSize = false;
            this.tEdit_Note6.DataText = "";
            this.tEdit_Note6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note6.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note6.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note6.Location = new System.Drawing.Point(590, 8);
            this.tEdit_Note6.MaxLength = 20;
            this.tEdit_Note6.Name = "tEdit_Note6";
            this.tEdit_Note6.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note6.TabIndex = 11;
            // 
            // uLabel_Note2Title
            // 
            appearance47.TextHAlignAsString = "Center";
            appearance47.TextVAlignAsString = "Middle";
            this.uLabel_Note2Title.Appearance = appearance47;
            this.uLabel_Note2Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note2Title.Location = new System.Drawing.Point(15, 34);
            this.uLabel_Note2Title.Name = "uLabel_Note2Title";
            this.uLabel_Note2Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note2Title.TabIndex = 494;
            this.uLabel_Note2Title.Text = "ìæà”êÊîıçlÇQ";
            // 
            // uButton_Note1Guide
            // 
            appearance48.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note1Guide.Appearance = appearance48;
            this.uButton_Note1Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note1Guide.Location = new System.Drawing.Point(445, 7);
            this.uButton_Note1Guide.Name = "uButton_Note1Guide";
            this.uButton_Note1Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note1Guide.TabIndex = 2;
            this.uButton_Note1Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note1Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // uLabel_Note6Title
            // 
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.uLabel_Note6Title.Appearance = appearance49;
            this.uLabel_Note6Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note6Title.Location = new System.Drawing.Point(485, 8);
            this.uLabel_Note6Title.Name = "uLabel_Note6Title";
            this.uLabel_Note6Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note6Title.TabIndex = 503;
            this.uLabel_Note6Title.Text = "ìæà”êÊîıçlÇU";
            // 
            // tEdit_Note1
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note1.ActiveAppearance = appearance50;
            appearance304.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note1.Appearance = appearance304;
            this.tEdit_Note1.AutoSelect = true;
            this.tEdit_Note1.AutoSize = false;
            this.tEdit_Note1.DataText = "";
            this.tEdit_Note1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note1.Location = new System.Drawing.Point(120, 8);
            this.tEdit_Note1.MaxLength = 20;
            this.tEdit_Note1.Name = "tEdit_Note1";
            this.tEdit_Note1.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note1.TabIndex = 1;
            // 
            // uLabel_Note1Title
            // 
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.uLabel_Note1Title.Appearance = appearance51;
            this.uLabel_Note1Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note1Title.Location = new System.Drawing.Point(15, 8);
            this.uLabel_Note1Title.Name = "uLabel_Note1Title";
            this.uLabel_Note1Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note1Title.TabIndex = 493;
            this.uLabel_Note1Title.Text = "ìæà”êÊîıçlÇP";
            // 
            // uLabel_Note5Title
            // 
            appearance52.TextHAlignAsString = "Center";
            appearance52.TextVAlignAsString = "Middle";
            this.uLabel_Note5Title.Appearance = appearance52;
            this.uLabel_Note5Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note5Title.Location = new System.Drawing.Point(15, 112);
            this.uLabel_Note5Title.Name = "uLabel_Note5Title";
            this.uLabel_Note5Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note5Title.TabIndex = 501;
            this.uLabel_Note5Title.Text = "ìæà”êÊîıçlÇT";
            // 
            // uLabel_Note4Title
            // 
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.uLabel_Note4Title.Appearance = appearance53;
            this.uLabel_Note4Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note4Title.Location = new System.Drawing.Point(15, 86);
            this.uLabel_Note4Title.Name = "uLabel_Note4Title";
            this.uLabel_Note4Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note4Title.TabIndex = 499;
            this.uLabel_Note4Title.Text = "ìæà”êÊîıçlÇS";
            // 
            // uLabel_Note3Title
            // 
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.uLabel_Note3Title.Appearance = appearance54;
            this.uLabel_Note3Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note3Title.Location = new System.Drawing.Point(15, 60);
            this.uLabel_Note3Title.Name = "uLabel_Note3Title";
            this.uLabel_Note3Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note3Title.TabIndex = 495;
            this.uLabel_Note3Title.Text = "ìæà”êÊîıçlÇR";
            // 
            // uButton_Note10Guide
            // 
            appearance55.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance55.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note10Guide.Appearance = appearance55;
            this.uButton_Note10Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note10Guide.Location = new System.Drawing.Point(915, 111);
            this.uButton_Note10Guide.Name = "uButton_Note10Guide";
            this.uButton_Note10Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note10Guide.TabIndex = 20;
            this.uButton_Note10Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note10Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // tEdit_Note10
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note10.ActiveAppearance = appearance56;
            appearance309.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note10.Appearance = appearance309;
            this.tEdit_Note10.AutoSelect = true;
            this.tEdit_Note10.AutoSize = false;
            this.tEdit_Note10.DataText = "";
            this.tEdit_Note10.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note10.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note10.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note10.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note10.Location = new System.Drawing.Point(590, 112);
            this.tEdit_Note10.MaxLength = 20;
            this.tEdit_Note10.Name = "tEdit_Note10";
            this.tEdit_Note10.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note10.TabIndex = 19;
            // 
            // uButton_Note5Guide
            // 
            appearance57.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance57.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note5Guide.Appearance = appearance57;
            this.uButton_Note5Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note5Guide.Location = new System.Drawing.Point(445, 111);
            this.uButton_Note5Guide.Name = "uButton_Note5Guide";
            this.uButton_Note5Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note5Guide.TabIndex = 10;
            this.uButton_Note5Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note5Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // uLabel_Note10Title
            // 
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.uLabel_Note10Title.Appearance = appearance58;
            this.uLabel_Note10Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Note10Title.Location = new System.Drawing.Point(485, 112);
            this.uLabel_Note10Title.Name = "uLabel_Note10Title";
            this.uLabel_Note10Title.Size = new System.Drawing.Size(100, 24);
            this.uLabel_Note10Title.TabIndex = 524;
            this.uLabel_Note10Title.Text = "ìæà”êÊîıçl10";
            // 
            // tEdit_Note5
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Note5.ActiveAppearance = appearance59;
            appearance308.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Note5.Appearance = appearance308;
            this.tEdit_Note5.AutoSelect = true;
            this.tEdit_Note5.AutoSize = false;
            this.tEdit_Note5.DataText = "";
            this.tEdit_Note5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Note5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_Note5.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Note5.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Note5.Location = new System.Drawing.Point(120, 112);
            this.tEdit_Note5.MaxLength = 20;
            this.tEdit_Note5.Name = "tEdit_Note5";
            this.tEdit_Note5.Size = new System.Drawing.Size(321, 22);
            this.tEdit_Note5.TabIndex = 9;
            // 
            // uButton_Note9Guide
            // 
            appearance60.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance60.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note9Guide.Appearance = appearance60;
            this.uButton_Note9Guide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note9Guide.Location = new System.Drawing.Point(915, 85);
            this.uButton_Note9Guide.Name = "uButton_Note9Guide";
            this.uButton_Note9Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note9Guide.TabIndex = 18;
            this.uButton_Note9Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note9Guide.Click += new System.EventHandler(this.uButton_Note1Guide_Click);
            // 
            // SubInfo4_UTabPageControl
            // 
            this.SubInfo4_UTabPageControl.Controls.Add(this.panel_SubInfo4);
            this.SubInfo4_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo4_UTabPageControl.Name = "SubInfo4_UTabPageControl";
            this.SubInfo4_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo4
            // 
            this.panel_SubInfo4.Controls.Add(this.rButton_MainSendMailAddrCd1);
            this.panel_SubInfo4.Controls.Add(this.rButton_MainSendMailAddrCd0);
            this.panel_SubInfo4.Controls.Add(this.tComboEditor_MailAddrKindCode2);
            this.panel_SubInfo4.Controls.Add(this.tComboEditor_MailAddrKindCode1);
            this.panel_SubInfo4.Controls.Add(this.tComboEditor_MailSendCode2);
            this.panel_SubInfo4.Controls.Add(this.tComboEditor_MailSendCode1);
            this.panel_SubInfo4.Controls.Add(this.tEdit_MailAddress2);
            this.panel_SubInfo4.Controls.Add(this.tEdit_MailAddress1);
            this.panel_SubInfo4.Location = new System.Drawing.Point(0, 0);
            this.panel_SubInfo4.Name = "panel_SubInfo4";
            this.panel_SubInfo4.Size = new System.Drawing.Size(999, 150);
            this.panel_SubInfo4.TabIndex = 1106;
            // 
            // rButton_MainSendMailAddrCd1
            // 
            this.rButton_MainSendMailAddrCd1.AutoSize = true;
            this.rButton_MainSendMailAddrCd1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rButton_MainSendMailAddrCd1.Location = new System.Drawing.Point(16, 32);
            this.rButton_MainSendMailAddrCd1.Name = "rButton_MainSendMailAddrCd1";
            this.rButton_MainSendMailAddrCd1.Size = new System.Drawing.Size(137, 17);
            this.rButton_MainSendMailAddrCd1.TabIndex = 4;
            this.rButton_MainSendMailAddrCd1.Text = "ÉÅÅ[ÉãÉAÉhÉåÉXÇQ";
            this.rButton_MainSendMailAddrCd1.UseVisualStyleBackColor = true;
            this.rButton_MainSendMailAddrCd1.Enter += new System.EventHandler(this.rButton_MainSendMailAddrCd0_Enter);
            // 
            // rButton_MainSendMailAddrCd0
            // 
            this.rButton_MainSendMailAddrCd0.AutoSize = true;
            this.rButton_MainSendMailAddrCd0.Checked = true;
            this.rButton_MainSendMailAddrCd0.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rButton_MainSendMailAddrCd0.Location = new System.Drawing.Point(16, 9);
            this.rButton_MainSendMailAddrCd0.Name = "rButton_MainSendMailAddrCd0";
            this.rButton_MainSendMailAddrCd0.Size = new System.Drawing.Size(137, 17);
            this.rButton_MainSendMailAddrCd0.TabIndex = 0;
            this.rButton_MainSendMailAddrCd0.TabStop = true;
            this.rButton_MainSendMailAddrCd0.Text = "ÉÅÅ[ÉãÉAÉhÉåÉXÇP";
            this.rButton_MainSendMailAddrCd0.UseVisualStyleBackColor = true;
            this.rButton_MainSendMailAddrCd0.Enter += new System.EventHandler(this.rButton_MainSendMailAddrCd0_Enter);
            // 
            // tComboEditor_MailAddrKindCode2
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailAddrKindCode2.ActiveAppearance = appearance62;
            appearance275.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance275.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_MailAddrKindCode2.Appearance = appearance275;
            this.tComboEditor_MailAddrKindCode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_MailAddrKindCode2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailAddrKindCode2.ItemAppearance = appearance63;
            this.tComboEditor_MailAddrKindCode2.Location = new System.Drawing.Point(813, 30);
            this.tComboEditor_MailAddrKindCode2.Name = "tComboEditor_MailAddrKindCode2";
            this.tComboEditor_MailAddrKindCode2.Size = new System.Drawing.Size(170, 22);
            this.tComboEditor_MailAddrKindCode2.TabIndex = 7;
            // 
            // tComboEditor_MailAddrKindCode1
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailAddrKindCode1.ActiveAppearance = appearance64;
            appearance276.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance276.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_MailAddrKindCode1.Appearance = appearance276;
            this.tComboEditor_MailAddrKindCode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_MailAddrKindCode1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailAddrKindCode1.ItemAppearance = appearance65;
            this.tComboEditor_MailAddrKindCode1.Location = new System.Drawing.Point(813, 7);
            this.tComboEditor_MailAddrKindCode1.Name = "tComboEditor_MailAddrKindCode1";
            this.tComboEditor_MailAddrKindCode1.Size = new System.Drawing.Size(170, 22);
            this.tComboEditor_MailAddrKindCode1.TabIndex = 3;
            // 
            // tComboEditor_MailSendCode2
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailSendCode2.ActiveAppearance = appearance66;
            appearance274.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance274.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_MailSendCode2.Appearance = appearance274;
            this.tComboEditor_MailSendCode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_MailSendCode2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailSendCode2.ItemAppearance = appearance67;
            this.tComboEditor_MailSendCode2.Location = new System.Drawing.Point(691, 30);
            this.tComboEditor_MailSendCode2.Name = "tComboEditor_MailSendCode2";
            this.tComboEditor_MailSendCode2.Size = new System.Drawing.Size(118, 22);
            this.tComboEditor_MailSendCode2.TabIndex = 6;
            // 
            // tComboEditor_MailSendCode1
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailSendCode1.ActiveAppearance = appearance68;
            appearance273.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance273.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_MailSendCode1.Appearance = appearance273;
            this.tComboEditor_MailSendCode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_MailSendCode1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_MailSendCode1.ItemAppearance = appearance69;
            this.tComboEditor_MailSendCode1.Location = new System.Drawing.Point(691, 7);
            this.tComboEditor_MailSendCode1.Name = "tComboEditor_MailSendCode1";
            this.tComboEditor_MailSendCode1.Size = new System.Drawing.Size(118, 22);
            this.tComboEditor_MailSendCode1.TabIndex = 2;
            // 
            // tEdit_MailAddress2
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MailAddress2.ActiveAppearance = appearance70;
            appearance315.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_MailAddress2.Appearance = appearance315;
            this.tEdit_MailAddress2.AutoSelect = true;
            this.tEdit_MailAddress2.DataText = "";
            this.tEdit_MailAddress2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MailAddress2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MailAddress2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MailAddress2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MailAddress2.Location = new System.Drawing.Point(159, 30);
            this.tEdit_MailAddress2.MaxLength = 64;
            this.tEdit_MailAddress2.Name = "tEdit_MailAddress2";
            this.tEdit_MailAddress2.Size = new System.Drawing.Size(527, 22);
            this.tEdit_MailAddress2.TabIndex = 5;
            // 
            // tEdit_MailAddress1
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MailAddress1.ActiveAppearance = appearance71;
            appearance314.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_MailAddress1.Appearance = appearance314;
            this.tEdit_MailAddress1.AutoSelect = true;
            this.tEdit_MailAddress1.DataText = "";
            this.tEdit_MailAddress1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MailAddress1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MailAddress1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MailAddress1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MailAddress1.Location = new System.Drawing.Point(159, 7);
            this.tEdit_MailAddress1.MaxLength = 64;
            this.tEdit_MailAddress1.Name = "tEdit_MailAddress1";
            this.tEdit_MailAddress1.Size = new System.Drawing.Size(527, 22);
            this.tEdit_MailAddress1.TabIndex = 1;
            // 
            // SubInfo5_UTabPageControl
            // 
            this.SubInfo5_UTabPageControl.Controls.Add(this.panel_SubInfo5);
            this.SubInfo5_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo5_UTabPageControl.Name = "SubInfo5_UTabPageControl";
            this.SubInfo5_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo5
            // 
            this.panel_SubInfo5.Controls.Add(this.tEdit_AccountNoInfo3);
            this.panel_SubInfo5.Controls.Add(this.tEdit_AccountNoInfo2);
            this.panel_SubInfo5.Controls.Add(this.tEdit_AccountNoInfo1);
            this.panel_SubInfo5.Controls.Add(this.ultraLabel23);
            this.panel_SubInfo5.Controls.Add(this.ultraLabel21);
            this.panel_SubInfo5.Controls.Add(this.ultraLabel20);
            this.panel_SubInfo5.Location = new System.Drawing.Point(-1, -1);
            this.panel_SubInfo5.Name = "panel_SubInfo5";
            this.panel_SubInfo5.Size = new System.Drawing.Size(999, 150);
            this.panel_SubInfo5.TabIndex = 1107;
            // 
            // tEdit_AccountNoInfo3
            // 
            appearance339.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_AccountNoInfo3.ActiveAppearance = appearance339;
            appearance340.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_AccountNoInfo3.Appearance = appearance340;
            this.tEdit_AccountNoInfo3.AutoSelect = true;
            this.tEdit_AccountNoInfo3.AutoSize = false;
            this.tEdit_AccountNoInfo3.DataText = "";
            this.tEdit_AccountNoInfo3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_AccountNoInfo3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_AccountNoInfo3.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_AccountNoInfo3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_AccountNoInfo3.Location = new System.Drawing.Point(118, 63);
            this.tEdit_AccountNoInfo3.MaxLength = 60;
            this.tEdit_AccountNoInfo3.Name = "tEdit_AccountNoInfo3";
            this.tEdit_AccountNoInfo3.Size = new System.Drawing.Size(843, 22);
            this.tEdit_AccountNoInfo3.TabIndex = 365;
            // 
            // tEdit_AccountNoInfo2
            // 
            appearance341.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_AccountNoInfo2.ActiveAppearance = appearance341;
            appearance342.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_AccountNoInfo2.Appearance = appearance342;
            this.tEdit_AccountNoInfo2.AutoSelect = true;
            this.tEdit_AccountNoInfo2.AutoSize = false;
            this.tEdit_AccountNoInfo2.DataText = "";
            this.tEdit_AccountNoInfo2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_AccountNoInfo2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_AccountNoInfo2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_AccountNoInfo2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_AccountNoInfo2.Location = new System.Drawing.Point(118, 35);
            this.tEdit_AccountNoInfo2.MaxLength = 60;
            this.tEdit_AccountNoInfo2.Name = "tEdit_AccountNoInfo2";
            this.tEdit_AccountNoInfo2.Size = new System.Drawing.Size(843, 22);
            this.tEdit_AccountNoInfo2.TabIndex = 364;
            // 
            // tEdit_AccountNoInfo1
            // 
            appearance343.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_AccountNoInfo1.ActiveAppearance = appearance343;
            appearance344.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_AccountNoInfo1.Appearance = appearance344;
            this.tEdit_AccountNoInfo1.AutoSelect = true;
            this.tEdit_AccountNoInfo1.AutoSize = false;
            this.tEdit_AccountNoInfo1.DataText = "";
            this.tEdit_AccountNoInfo1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_AccountNoInfo1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_AccountNoInfo1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_AccountNoInfo1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_AccountNoInfo1.Location = new System.Drawing.Point(118, 7);
            this.tEdit_AccountNoInfo1.MaxLength = 60;
            this.tEdit_AccountNoInfo1.Name = "tEdit_AccountNoInfo1";
            this.tEdit_AccountNoInfo1.Size = new System.Drawing.Size(843, 22);
            this.tEdit_AccountNoInfo1.TabIndex = 363;
            // 
            // ultraLabel23
            // 
            appearance345.TextHAlignAsString = "Center";
            appearance345.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance345;
            this.ultraLabel23.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(30, 63);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(80, 24);
            this.ultraLabel23.TabIndex = 362;
            this.ultraLabel23.Text = "ã‚çså˚ç¿ÇR";
            // 
            // ultraLabel21
            // 
            appearance346.TextHAlignAsString = "Center";
            appearance346.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance346;
            this.ultraLabel21.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(30, 35);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(80, 24);
            this.ultraLabel21.TabIndex = 361;
            this.ultraLabel21.Text = "ã‚çså˚ç¿ÇQ";
            // 
            // ultraLabel20
            // 
            appearance347.TextHAlignAsString = "Center";
            appearance347.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance347;
            this.ultraLabel20.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(30, 7);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(80, 24);
            this.ultraLabel20.TabIndex = 360;
            this.ultraLabel20.Text = "ã‚çså˚ç¿ÇP";
            // 
            // SubInfo6_UTabPageControl
            // 
            this.SubInfo6_UTabPageControl.Controls.Add(this.panel_SubInfo6);
            this.SubInfo6_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo6_UTabPageControl.Name = "SubInfo6_UTabPageControl";
            this.SubInfo6_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo6
            // 
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_SlipTtlBillOutputDiv);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_DetailBillOutputCode);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_TotalBillOutputDiv);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel42);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel39);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel16);
            this.panel_SubInfo6.Controls.Add(this.UOESlipPrtDiv_uLabel);
            this.panel_SubInfo6.Controls.Add(this.EstimatePrtDiv_uLabel);
            this.panel_SubInfo6.Controls.Add(this.ShipmSlipPrtDiv_uLabel);
            this.panel_SubInfo6.Controls.Add(this.AcpOdrrSlipPrtDiv_uLabel);
            this.panel_SubInfo6.Controls.Add(this.SalesSlipPrtDiv_uLabel);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_UOESlipPrtDiv);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_EstimatePrtDiv);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_ShipmSlipPrtDiv);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_AcpOdrrSlipPrtDiv);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_SalesSlipPrtDiv);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel63);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_QrcodePrtCd);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_ReceiptOutputCode);
            this.panel_SubInfo6.Controls.Add(this.ReceiptOutputCode_uLabel);
            this.panel_SubInfo6.Controls.Add(this.DmOutCodeTitle_ULabel);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_DmOutCode);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_CustSlipNoMngCd);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel38);
            this.panel_SubInfo6.Controls.Add(this.ultraLabel26);
            this.panel_SubInfo6.Controls.Add(this.tComboEditor_CustomerSlipNoDiv);
            this.panel_SubInfo6.Location = new System.Drawing.Point(-1, -1);
            this.panel_SubInfo6.Name = "panel_SubInfo6";
            this.panel_SubInfo6.Size = new System.Drawing.Size(1000, 150);
            this.panel_SubInfo6.TabIndex = 1108;
            // 
            // tComboEditor_SlipTtlBillOutputDiv
            // 
            appearance216.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SlipTtlBillOutputDiv.ActiveAppearance = appearance216;
            appearance319.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance319.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SlipTtlBillOutputDiv.Appearance = appearance319;
            this.tComboEditor_SlipTtlBillOutputDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SlipTtlBillOutputDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance320.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SlipTtlBillOutputDiv.ItemAppearance = appearance320;
            this.tComboEditor_SlipTtlBillOutputDiv.Location = new System.Drawing.Point(760, 63);
            this.tComboEditor_SlipTtlBillOutputDiv.Name = "tComboEditor_SlipTtlBillOutputDiv";
            this.tComboEditor_SlipTtlBillOutputDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_SlipTtlBillOutputDiv.TabIndex = 1282;
            this.tComboEditor_SlipTtlBillOutputDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SlipTtlBillOutputDiv_SelectionChangeCommitted);
            // 
            // tComboEditor_DetailBillOutputCode
            // 
            appearance351.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DetailBillOutputCode.ActiveAppearance = appearance351;
            appearance352.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance352.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_DetailBillOutputCode.Appearance = appearance352;
            this.tComboEditor_DetailBillOutputCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DetailBillOutputCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance353.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DetailBillOutputCode.ItemAppearance = appearance353;
            this.tComboEditor_DetailBillOutputCode.Location = new System.Drawing.Point(760, 35);
            this.tComboEditor_DetailBillOutputCode.Name = "tComboEditor_DetailBillOutputCode";
            this.tComboEditor_DetailBillOutputCode.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_DetailBillOutputCode.TabIndex = 1281;
            this.tComboEditor_DetailBillOutputCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_DetailBillOutputCode_SelectionChangeCommitted);
            // 
            // tComboEditor_TotalBillOutputDiv
            // 
            appearance348.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TotalBillOutputDiv.ActiveAppearance = appearance348;
            appearance349.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance349.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_TotalBillOutputDiv.Appearance = appearance349;
            this.tComboEditor_TotalBillOutputDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TotalBillOutputDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance350.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TotalBillOutputDiv.ItemAppearance = appearance350;
            this.tComboEditor_TotalBillOutputDiv.Location = new System.Drawing.Point(760, 7);
            this.tComboEditor_TotalBillOutputDiv.Name = "tComboEditor_TotalBillOutputDiv";
            this.tComboEditor_TotalBillOutputDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_TotalBillOutputDiv.TabIndex = 1280;
            this.tComboEditor_TotalBillOutputDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_TotalBillOutputDiv_SelectionChangeCommitted);
            // 
            // ultraLabel42
            // 
            appearance131.TextHAlignAsString = "Center";
            appearance131.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance131;
            this.ultraLabel42.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel42.Location = new System.Drawing.Point(623, 63);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(131, 22);
            this.ultraLabel42.TabIndex = 1278;
            this.ultraLabel42.Text = "ì`ï[çáåvêøãÅèëèoóÕ";
            // 
            // ultraLabel39
            // 
            appearance159.TextHAlignAsString = "Center";
            appearance159.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance159;
            this.ultraLabel39.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel39.Location = new System.Drawing.Point(623, 35);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(131, 22);
            this.ultraLabel39.TabIndex = 1277;
            this.ultraLabel39.Text = "ñæç◊êøãÅèëèoóÕ";
            // 
            // ultraLabel16
            // 
            appearance265.TextHAlignAsString = "Center";
            appearance265.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance265;
            this.ultraLabel16.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel16.Location = new System.Drawing.Point(623, 7);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(131, 22);
            this.ultraLabel16.TabIndex = 1276;
            this.ultraLabel16.Text = "çáåvêøãÅèëèoóÕ";
            // 
            // UOESlipPrtDiv_uLabel
            // 
            appearance321.TextHAlignAsString = "Center";
            appearance321.TextVAlignAsString = "Middle";
            this.UOESlipPrtDiv_uLabel.Appearance = appearance321;
            this.UOESlipPrtDiv_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.UOESlipPrtDiv_uLabel.Location = new System.Drawing.Point(343, 119);
            this.UOESlipPrtDiv_uLabel.Name = "UOESlipPrtDiv_uLabel";
            this.UOESlipPrtDiv_uLabel.Size = new System.Drawing.Size(107, 22);
            this.UOESlipPrtDiv_uLabel.TabIndex = 1275;
            this.UOESlipPrtDiv_uLabel.Text = "UOEì`ï[èoóÕ";
            // 
            // EstimatePrtDiv_uLabel
            // 
            appearance113.TextHAlignAsString = "Center";
            appearance113.TextVAlignAsString = "Middle";
            this.EstimatePrtDiv_uLabel.Appearance = appearance113;
            this.EstimatePrtDiv_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.EstimatePrtDiv_uLabel.Location = new System.Drawing.Point(343, 91);
            this.EstimatePrtDiv_uLabel.Name = "EstimatePrtDiv_uLabel";
            this.EstimatePrtDiv_uLabel.Size = new System.Drawing.Size(107, 22);
            this.EstimatePrtDiv_uLabel.TabIndex = 1274;
            this.EstimatePrtDiv_uLabel.Text = "å©êœì`ï[èoóÕ";
            // 
            // ShipmSlipPrtDiv_uLabel
            // 
            appearance126.TextHAlignAsString = "Center";
            appearance126.TextVAlignAsString = "Middle";
            this.ShipmSlipPrtDiv_uLabel.Appearance = appearance126;
            this.ShipmSlipPrtDiv_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShipmSlipPrtDiv_uLabel.Location = new System.Drawing.Point(343, 63);
            this.ShipmSlipPrtDiv_uLabel.Name = "ShipmSlipPrtDiv_uLabel";
            this.ShipmSlipPrtDiv_uLabel.Size = new System.Drawing.Size(107, 22);
            this.ShipmSlipPrtDiv_uLabel.TabIndex = 1273;
            this.ShipmSlipPrtDiv_uLabel.Text = "ë›èoì`ï[èoóÕ";
            // 
            // AcpOdrrSlipPrtDiv_uLabel
            // 
            appearance138.TextHAlignAsString = "Center";
            appearance138.TextVAlignAsString = "Middle";
            this.AcpOdrrSlipPrtDiv_uLabel.Appearance = appearance138;
            this.AcpOdrrSlipPrtDiv_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AcpOdrrSlipPrtDiv_uLabel.Location = new System.Drawing.Point(343, 35);
            this.AcpOdrrSlipPrtDiv_uLabel.Name = "AcpOdrrSlipPrtDiv_uLabel";
            this.AcpOdrrSlipPrtDiv_uLabel.Size = new System.Drawing.Size(107, 22);
            this.AcpOdrrSlipPrtDiv_uLabel.TabIndex = 1272;
            this.AcpOdrrSlipPrtDiv_uLabel.Text = "éÛíçì`ï[èoóÕ";
            // 
            // SalesSlipPrtDiv_uLabel
            // 
            appearance139.TextHAlignAsString = "Center";
            appearance139.TextVAlignAsString = "Middle";
            this.SalesSlipPrtDiv_uLabel.Appearance = appearance139;
            this.SalesSlipPrtDiv_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SalesSlipPrtDiv_uLabel.Location = new System.Drawing.Point(343, 7);
            this.SalesSlipPrtDiv_uLabel.Name = "SalesSlipPrtDiv_uLabel";
            this.SalesSlipPrtDiv_uLabel.Size = new System.Drawing.Size(107, 22);
            this.SalesSlipPrtDiv_uLabel.TabIndex = 1271;
            this.SalesSlipPrtDiv_uLabel.Text = "î[ïièëèoóÕ";
            // 
            // tComboEditor_UOESlipPrtDiv
            // 
            this.tComboEditor_UOESlipPrtDiv.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance322.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_UOESlipPrtDiv.ActiveAppearance = appearance322;
            appearance323.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance323.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_UOESlipPrtDiv.Appearance = appearance323;
            this.tComboEditor_UOESlipPrtDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_UOESlipPrtDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance324.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_UOESlipPrtDiv.ItemAppearance = appearance324;
            this.tComboEditor_UOESlipPrtDiv.Location = new System.Drawing.Point(450, 119);
            this.tComboEditor_UOESlipPrtDiv.Name = "tComboEditor_UOESlipPrtDiv";
            this.tComboEditor_UOESlipPrtDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_UOESlipPrtDiv.TabIndex = 1270;
            this.tComboEditor_UOESlipPrtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_UOESlipPrtDiv_SelectionChangeCommitted);
            // 
            // tComboEditor_EstimatePrtDiv
            // 
            appearance143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_EstimatePrtDiv.ActiveAppearance = appearance143;
            appearance170.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance170.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_EstimatePrtDiv.Appearance = appearance170;
            this.tComboEditor_EstimatePrtDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_EstimatePrtDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance171.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_EstimatePrtDiv.ItemAppearance = appearance171;
            this.tComboEditor_EstimatePrtDiv.Location = new System.Drawing.Point(450, 91);
            this.tComboEditor_EstimatePrtDiv.Name = "tComboEditor_EstimatePrtDiv";
            this.tComboEditor_EstimatePrtDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_EstimatePrtDiv.TabIndex = 1269;
            this.tComboEditor_EstimatePrtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_EstimatePrtDiv_SelectionChangeCommitted);
            // 
            // tComboEditor_ShipmSlipPrtDiv
            // 
            appearance175.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ShipmSlipPrtDiv.ActiveAppearance = appearance175;
            appearance176.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance176.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_ShipmSlipPrtDiv.Appearance = appearance176;
            this.tComboEditor_ShipmSlipPrtDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_ShipmSlipPrtDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance177.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ShipmSlipPrtDiv.ItemAppearance = appearance177;
            this.tComboEditor_ShipmSlipPrtDiv.Location = new System.Drawing.Point(450, 63);
            this.tComboEditor_ShipmSlipPrtDiv.Name = "tComboEditor_ShipmSlipPrtDiv";
            this.tComboEditor_ShipmSlipPrtDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_ShipmSlipPrtDiv.TabIndex = 1268;
            this.tComboEditor_ShipmSlipPrtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_ShipmSlipPrtDiv_SelectionChangeCommitted);
            // 
            // tComboEditor_AcpOdrrSlipPrtDiv
            // 
            appearance178.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AcpOdrrSlipPrtDiv.ActiveAppearance = appearance178;
            appearance179.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance179.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_AcpOdrrSlipPrtDiv.Appearance = appearance179;
            this.tComboEditor_AcpOdrrSlipPrtDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AcpOdrrSlipPrtDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance180.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AcpOdrrSlipPrtDiv.ItemAppearance = appearance180;
            this.tComboEditor_AcpOdrrSlipPrtDiv.Location = new System.Drawing.Point(450, 35);
            this.tComboEditor_AcpOdrrSlipPrtDiv.Name = "tComboEditor_AcpOdrrSlipPrtDiv";
            this.tComboEditor_AcpOdrrSlipPrtDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_AcpOdrrSlipPrtDiv.TabIndex = 1267;
            this.tComboEditor_AcpOdrrSlipPrtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_AcpOdrrSlipPrtDiv_SelectionChangeCommitted);
            // 
            // tComboEditor_SalesSlipPrtDiv
            // 
            appearance329.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipPrtDiv.ActiveAppearance = appearance329;
            appearance330.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance330.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SalesSlipPrtDiv.Appearance = appearance330;
            this.tComboEditor_SalesSlipPrtDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SalesSlipPrtDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance332.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesSlipPrtDiv.ItemAppearance = appearance332;
            this.tComboEditor_SalesSlipPrtDiv.Location = new System.Drawing.Point(450, 7);
            this.tComboEditor_SalesSlipPrtDiv.Name = "tComboEditor_SalesSlipPrtDiv";
            this.tComboEditor_SalesSlipPrtDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_SalesSlipPrtDiv.TabIndex = 1266;
            this.tComboEditor_SalesSlipPrtDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SalesSlipPrtDiv_SelectionChangeCommitted);
            // 
            // ultraLabel63
            // 
            appearance234.TextHAlignAsString = "Center";
            appearance234.TextVAlignAsString = "Middle";
            this.ultraLabel63.Appearance = appearance234;
            this.ultraLabel63.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel63.Location = new System.Drawing.Point(8, 119);
            this.ultraLabel63.Name = "ultraLabel63";
            this.ultraLabel63.Size = new System.Drawing.Size(119, 22);
            this.ultraLabel63.TabIndex = 508;
            this.ultraLabel63.Text = "ÇpÇqÉRÅ[ÉhàÛç¸";
            // 
            // tComboEditor_QrcodePrtCd
            // 
            appearance205.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_QrcodePrtCd.ActiveAppearance = appearance205;
            appearance281.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance281.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_QrcodePrtCd.Appearance = appearance281;
            this.tComboEditor_QrcodePrtCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_QrcodePrtCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance206.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_QrcodePrtCd.ItemAppearance = appearance206;
            this.tComboEditor_QrcodePrtCd.Location = new System.Drawing.Point(134, 119);
            this.tComboEditor_QrcodePrtCd.Name = "tComboEditor_QrcodePrtCd";
            this.tComboEditor_QrcodePrtCd.Size = new System.Drawing.Size(208, 22);
            this.tComboEditor_QrcodePrtCd.TabIndex = 507;
            this.tComboEditor_QrcodePrtCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_QrcodePrtCd_SelectionChangeCommitted);
            // 
            // tComboEditor_ReceiptOutputCode
            // 
            appearance326.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ReceiptOutputCode.ActiveAppearance = appearance326;
            appearance327.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance327.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_ReceiptOutputCode.Appearance = appearance327;
            this.tComboEditor_ReceiptOutputCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_ReceiptOutputCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance328.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ReceiptOutputCode.ItemAppearance = appearance328;
            this.tComboEditor_ReceiptOutputCode.Location = new System.Drawing.Point(134, 7);
            this.tComboEditor_ReceiptOutputCode.Name = "tComboEditor_ReceiptOutputCode";
            this.tComboEditor_ReceiptOutputCode.Size = new System.Drawing.Size(208, 22);
            this.tComboEditor_ReceiptOutputCode.TabIndex = 311;
            this.tComboEditor_ReceiptOutputCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_ReceiptOutputCode_SelectionChangeCommitted);
            // 
            // ReceiptOutputCode_uLabel
            // 
            appearance325.TextHAlignAsString = "Center";
            appearance325.TextVAlignAsString = "Middle";
            this.ReceiptOutputCode_uLabel.Appearance = appearance325;
            this.ReceiptOutputCode_uLabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ReceiptOutputCode_uLabel.Location = new System.Drawing.Point(8, 7);
            this.ReceiptOutputCode_uLabel.Name = "ReceiptOutputCode_uLabel";
            this.ReceiptOutputCode_uLabel.Size = new System.Drawing.Size(119, 22);
            this.ReceiptOutputCode_uLabel.TabIndex = 505;
            this.ReceiptOutputCode_uLabel.Text = "óÃé˚èëèoóÕ";
            // 
            // DmOutCodeTitle_ULabel
            // 
            appearance264.TextHAlignAsString = "Center";
            appearance264.TextVAlignAsString = "Middle";
            this.DmOutCodeTitle_ULabel.Appearance = appearance264;
            this.DmOutCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DmOutCodeTitle_ULabel.Location = new System.Drawing.Point(8, 35);
            this.DmOutCodeTitle_ULabel.Name = "DmOutCodeTitle_ULabel";
            this.DmOutCodeTitle_ULabel.Size = new System.Drawing.Size(119, 22);
            this.DmOutCodeTitle_ULabel.TabIndex = 506;
            this.DmOutCodeTitle_ULabel.Text = "ìdéqí†ïÎèoóÕ";
            // 
            // tComboEditor_DmOutCode
            // 
            appearance266.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DmOutCode.ActiveAppearance = appearance266;
            appearance278.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance278.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_DmOutCode.Appearance = appearance278;
            this.tComboEditor_DmOutCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DmOutCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance267.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DmOutCode.ItemAppearance = appearance267;
            this.tComboEditor_DmOutCode.Location = new System.Drawing.Point(134, 35);
            this.tComboEditor_DmOutCode.Name = "tComboEditor_DmOutCode";
            this.tComboEditor_DmOutCode.Size = new System.Drawing.Size(208, 22);
            this.tComboEditor_DmOutCode.TabIndex = 312;
            this.tComboEditor_DmOutCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_DmOutCode_SelectionChangeCommitted);
            // 
            // tComboEditor_CustSlipNoMngCd
            // 
            appearance268.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustSlipNoMngCd.ActiveAppearance = appearance268;
            appearance279.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance279.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CustSlipNoMngCd.Appearance = appearance279;
            this.tComboEditor_CustSlipNoMngCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CustSlipNoMngCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance269.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustSlipNoMngCd.ItemAppearance = appearance269;
            this.tComboEditor_CustSlipNoMngCd.Location = new System.Drawing.Point(134, 63);
            this.tComboEditor_CustSlipNoMngCd.Name = "tComboEditor_CustSlipNoMngCd";
            this.tComboEditor_CustSlipNoMngCd.Size = new System.Drawing.Size(208, 22);
            this.tComboEditor_CustSlipNoMngCd.TabIndex = 1232;
            this.tComboEditor_CustSlipNoMngCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CustSlipNoMngCd_SelectionChangeCommitted);
            // 
            // ultraLabel38
            // 
            appearance133.TextHAlignAsString = "Center";
            appearance133.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance133;
            this.ultraLabel38.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel38.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel38.Location = new System.Drawing.Point(8, 63);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(119, 22);
            this.ultraLabel38.TabIndex = 1238;
            this.ultraLabel38.Text = "âºì`î‘çÜï\é¶ãÊï™";
            // 
            // ultraLabel26
            // 
            appearance106.TextHAlignAsString = "Center";
            appearance106.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance106;
            this.ultraLabel26.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel26.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel26.Location = new System.Drawing.Point(8, 91);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(119, 22);
            this.ultraLabel26.TabIndex = 1264;
            this.ultraLabel26.Text = "ì`ï[î‘çÜãÊï™";
            // 
            // tComboEditor_CustomerSlipNoDiv
            // 
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerSlipNoDiv.ActiveAppearance = appearance104;
            appearance280.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance280.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CustomerSlipNoDiv.Appearance = appearance280;
            this.tComboEditor_CustomerSlipNoDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CustomerSlipNoDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerSlipNoDiv.ItemAppearance = appearance105;
            this.tComboEditor_CustomerSlipNoDiv.Location = new System.Drawing.Point(134, 91);
            this.tComboEditor_CustomerSlipNoDiv.Name = "tComboEditor_CustomerSlipNoDiv";
            this.tComboEditor_CustomerSlipNoDiv.Size = new System.Drawing.Size(208, 22);
            this.tComboEditor_CustomerSlipNoDiv.TabIndex = 1265;
            this.tComboEditor_CustomerSlipNoDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CustomerSlipNoDiv_SelectionChangeCommitted);
            // 
            // SubInfo7_UTabPageControl
            // 
            this.SubInfo7_UTabPageControl.Controls.Add(this.panel_SubInfo7);
            this.SubInfo7_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo7_UTabPageControl.Name = "SubInfo7_UTabPageControl";
            this.SubInfo7_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo7
            // 
            this.panel_SubInfo7.Controls.Add(this.tEdit_SimplInqAcntAcntGrId);
            this.panel_SubInfo7.Controls.Add(this.ultraLabel65);
            this.panel_SubInfo7.Controls.Add(this.ultraLabel4);
            this.panel_SubInfo7.Controls.Add(this.tEdit_CustomerSecCode);
            this.panel_SubInfo7.Controls.Add(this.tComboEditor_OnlineKindDiv);
            this.panel_SubInfo7.Controls.Add(this.ultraLabel15);
            this.panel_SubInfo7.Controls.Add(this.tEdit_CustomerEpCode);
            this.panel_SubInfo7.Controls.Add(this.ultraLabel8);
            this.panel_SubInfo7.Location = new System.Drawing.Point(-1, -1);
            this.panel_SubInfo7.Name = "panel_SubInfo7";
            this.panel_SubInfo7.Size = new System.Drawing.Size(999, 150);
            this.panel_SubInfo7.TabIndex = 1279;
            // 
            // tEdit_SimplInqAcntAcntGrId
            // 
            appearance333.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SimplInqAcntAcntGrId.ActiveAppearance = appearance333;
            appearance334.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SimplInqAcntAcntGrId.Appearance = appearance334;
            this.tEdit_SimplInqAcntAcntGrId.AutoSelect = true;
            this.tEdit_SimplInqAcntAcntGrId.DataText = "";
            this.tEdit_SimplInqAcntAcntGrId.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SimplInqAcntAcntGrId.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SimplInqAcntAcntGrId.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SimplInqAcntAcntGrId.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.tEdit_SimplInqAcntAcntGrId.Location = new System.Drawing.Point(506, 35);
            this.tEdit_SimplInqAcntAcntGrId.MaxLength = 32;
            this.tEdit_SimplInqAcntAcntGrId.Name = "tEdit_SimplInqAcntAcntGrId";
            this.tEdit_SimplInqAcntAcntGrId.Size = new System.Drawing.Size(238, 22);
            this.tEdit_SimplInqAcntAcntGrId.TabIndex = 1279;
            // 
            // ultraLabel65
            // 
            appearance337.TextHAlignAsString = "Center";
            appearance337.TextVAlignAsString = "Middle";
            this.ultraLabel65.Appearance = appearance337;
            this.ultraLabel65.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel65.Location = new System.Drawing.Point(320, 35);
            this.ultraLabel65.Name = "ultraLabel65";
            this.ultraLabel65.Size = new System.Drawing.Size(180, 22);
            this.ultraLabel65.TabIndex = 1279;
            this.ultraLabel65.Text = "CMTÉAÉJÉEÉìÉgÉOÉãÅ[ÉvID";
            // 
            // ultraLabel4
            // 
            appearance338.TextHAlignAsString = "Center";
            appearance338.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance338;
            this.ultraLabel4.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(8, 7);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(132, 22);
            this.ultraLabel4.TabIndex = 1277;
            this.ultraLabel4.Text = "ÉIÉìÉâÉCÉìê⁄ë±ï˚ñ@";
            // 
            // tEdit_CustomerSecCode
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerSecCode.ActiveAppearance = appearance2;
            appearance296.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerSecCode.Appearance = appearance296;
            this.tEdit_CustomerSecCode.AutoSelect = true;
            this.tEdit_CustomerSecCode.DataText = "";
            this.tEdit_CustomerSecCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerSecCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_CustomerSecCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerSecCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_CustomerSecCode.Location = new System.Drawing.Point(146, 63);
            this.tEdit_CustomerSecCode.MaxLength = 6;
            this.tEdit_CustomerSecCode.Name = "tEdit_CustomerSecCode";
            this.tEdit_CustomerSecCode.Size = new System.Drawing.Size(59, 22);
            this.tEdit_CustomerSecCode.TabIndex = 1280;
            // 
            // tComboEditor_OnlineKindDiv
            // 
            this.tComboEditor_OnlineKindDiv.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance207.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OnlineKindDiv.ActiveAppearance = appearance207;
            appearance277.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance277.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_OnlineKindDiv.Appearance = appearance277;
            this.tComboEditor_OnlineKindDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_OnlineKindDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance208.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OnlineKindDiv.ItemAppearance = appearance208;
            this.tComboEditor_OnlineKindDiv.Location = new System.Drawing.Point(146, 7);
            this.tComboEditor_OnlineKindDiv.Name = "tComboEditor_OnlineKindDiv";
            this.tComboEditor_OnlineKindDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_OnlineKindDiv.TabIndex = 1276;
            this.tComboEditor_OnlineKindDiv.SelectionChanged += new System.EventHandler(this.tComboEditor_OnlineKindDiv_SelectionChanged);
            this.tComboEditor_OnlineKindDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_OnlineKindDiv_SelectionChangeCommitted);
            // 
            // ultraLabel15
            // 
            appearance235.TextHAlignAsString = "Center";
            appearance235.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance235;
            this.ultraLabel15.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(8, 63);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(132, 22);
            this.ultraLabel15.TabIndex = 1277;
            this.ultraLabel15.Text = "ìæà”êÊãíì_ÉRÅ[Éh";
            // 
            // tEdit_CustomerEpCode
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerEpCode.ActiveAppearance = appearance75;
            appearance76.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerEpCode.Appearance = appearance76;
            this.tEdit_CustomerEpCode.AutoSelect = true;
            this.tEdit_CustomerEpCode.DataText = "";
            this.tEdit_CustomerEpCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerEpCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_CustomerEpCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerEpCode.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.tEdit_CustomerEpCode.Location = new System.Drawing.Point(146, 35);
            this.tEdit_CustomerEpCode.MaxLength = 16;
            this.tEdit_CustomerEpCode.Name = "tEdit_CustomerEpCode";
            this.tEdit_CustomerEpCode.Size = new System.Drawing.Size(128, 22);
            this.tEdit_CustomerEpCode.TabIndex = 1278;
            // 
            // ultraLabel8
            // 
            appearance77.TextHAlignAsString = "Center";
            appearance77.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance77;
            this.ultraLabel8.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(8, 35);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(132, 22);
            this.ultraLabel8.TabIndex = 1277;
            this.ultraLabel8.Text = "ìæà”êÊäÈã∆ÉRÅ[Éh";
            // 
            // SubInfo8_UTabPageControl
            // 
            this.SubInfo8_UTabPageControl.Controls.Add(this.panel_SubInfo8);
            this.SubInfo8_UTabPageControl.Location = new System.Drawing.Point(1, 1);
            this.SubInfo8_UTabPageControl.Name = "SubInfo8_UTabPageControl";
            this.SubInfo8_UTabPageControl.Size = new System.Drawing.Size(998, 149);
            // 
            // panel_SubInfo8
            // 
            this.panel_SubInfo8.Controls.Add(this.check_CustomerInfoGuideDisp);
            this.panel_SubInfo8.Controls.Add(this.memo_richTextBox);
            this.panel_SubInfo8.Location = new System.Drawing.Point(-1, -1);
            this.panel_SubInfo8.Name = "panel_SubInfo8";
            this.panel_SubInfo8.Size = new System.Drawing.Size(999, 150);
            this.panel_SubInfo8.TabIndex = 0;
            // 
            // check_CustomerInfoGuideDisp
            // 
            this.check_CustomerInfoGuideDisp.AutoSize = true;
            this.check_CustomerInfoGuideDisp.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.check_CustomerInfoGuideDisp.Location = new System.Drawing.Point(7, 4);
            this.check_CustomerInfoGuideDisp.Name = "check_CustomerInfoGuideDisp";
            this.check_CustomerInfoGuideDisp.Size = new System.Drawing.Size(166, 17);
            this.check_CustomerInfoGuideDisp.TabIndex = 1;
            this.check_CustomerInfoGuideDisp.Text = "ìæà”êÊèÓïÒÉKÉCÉhï\é¶";
            this.check_CustomerInfoGuideDisp.UseVisualStyleBackColor = true;
            // 
            // memo_richTextBox
            // 
            this.memo_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memo_richTextBox.DetectUrls = false;
            this.memo_richTextBox.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.memo_richTextBox.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.memo_richTextBox.Location = new System.Drawing.Point(7, 27);
            this.memo_richTextBox.MaxLength = 1000;
            this.memo_richTextBox.Name = "memo_richTextBox";
            this.memo_richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.memo_richTextBox.Size = new System.Drawing.Size(815, 111);
            this.memo_richTextBox.TabIndex = 0;
            this.memo_richTextBox.Text = "";
            this.memo_richTextBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.memo_richTextBox_MouseUp);
            // 
            // SubInfo1_UTabPageControl
            // 
            this.SubInfo1_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo1_UTabPageControl.Name = "SubInfo1_UTabPageControl";
            this.SubInfo1_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // BackGround_Panel
            // 
            this.BackGround_Panel.Controls.Add(this.Container_Panel);
            this.BackGround_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackGround_Panel.Location = new System.Drawing.Point(0, 0);
            this.BackGround_Panel.Name = "BackGround_Panel";
            this.BackGround_Panel.Size = new System.Drawing.Size(1013, 633);
            this.BackGround_Panel.TabIndex = 0;
            this.BackGround_Panel.SizeChanged += new System.EventHandler(this.BackGround_Panel_SizeChanged);
            // 
            // Container_Panel
            // 
            this.Container_Panel.AutoScroll = true;
            this.Container_Panel.Controls.Add(this.tEdit_JobTypeName);
            this.Container_Panel.Controls.Add(this.uButton_JobTypeCodeGuide);
            this.Container_Panel.Controls.Add(this.tEdit_SalesAreaNm);
            this.Container_Panel.Controls.Add(this.uButton_SalesAreaCdGuide);
            this.Container_Panel.Controls.Add(this.tEdit_BusinessTypeNm);
            this.Container_Panel.Controls.Add(this.uButton_BusinessTypeCdGuide);
            this.Container_Panel.Controls.Add(this.tEdit_HonorificTitle);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo8Title);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo7Title);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo6Title);
            this.Container_Panel.Controls.Add(this.tEdit_CustWarehouseCd);
            this.Container_Panel.Controls.Add(this.uButton_CustWarehouseGuide);
            this.Container_Panel.Controls.Add(this.ultraLabel50);
            this.Container_Panel.Controls.Add(this.tComboEditor_CarMngDivCd);
            this.Container_Panel.Controls.Add(this.ultraLabel49);
            this.Container_Panel.Controls.Add(this.uButton_ClaimSectionGuide);
            this.Container_Panel.Controls.Add(this.tEdit_ClaimSectionCode);
            this.Container_Panel.Controls.Add(this.ultraLabel37);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo0Title);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo5Title);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo4Title);
            this.Container_Panel.Controls.Add(this.tComboEditor_CorporateDivCode);
            this.Container_Panel.Controls.Add(this.CorporateDivCodeTitle_ULabel);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode1);
            this.Container_Panel.Controls.Add(this.ultraLabel28);
            this.Container_Panel.Controls.Add(this.CustAnalysCodeTitle_ULabel);
            this.Container_Panel.Controls.Add(this.tComboEditor_CustomerAttributeDiv);
            this.Container_Panel.Controls.Add(this.uLabel_SubInfo2Title);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode2);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode4);
            this.Container_Panel.Controls.Add(this.ultraLabel60);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode6);
            this.Container_Panel.Controls.Add(this.tNedit_NTimeCalcStDate);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode3);
            this.Container_Panel.Controls.Add(this.ultraLabel58);
            this.Container_Panel.Controls.Add(this.tNedit_CustAnalysCode5);
            this.Container_Panel.Controls.Add(this.uLabel_ClaimName1);
            this.Container_Panel.Controls.Add(this.uButton_MngSectionNmGuide);
            this.Container_Panel.Controls.Add(this.tEdit_MngSectionNm);
            this.Container_Panel.Controls.Add(this.ultraLabel57);
            this.Container_Panel.Controls.Add(this.tEdit_OldCustomerAgentNm);
            this.Container_Panel.Controls.Add(this.tNedit_ClaimCode);
            this.Container_Panel.Controls.Add(this.ultraLabel55);
            this.Container_Panel.Controls.Add(this.tNedit_SalesCnsTaxFrcProcCd);
            this.Container_Panel.Controls.Add(this.tNedit_SalesMoneyFrcProcCd);
            this.Container_Panel.Controls.Add(this.tNedit_SalesUnPrcFrcProcCd);
            this.Container_Panel.Controls.Add(this.uButton_SalesCnsTaxFrcProcCdGuide);
            this.Container_Panel.Controls.Add(this.uButton_SalesMoneyFrcProcCdGuide);
            this.Container_Panel.Controls.Add(this.uButton_SalesUnPrcFrcProcCdGuide);
            this.Container_Panel.Controls.Add(this.ultraLabel54);
            this.Container_Panel.Controls.Add(this.ultraLabel52);
            this.Container_Panel.Controls.Add(this.tComboEditor_CustCTaXLayRefCd);
            this.Container_Panel.Controls.Add(this.ultraLabel53);
            this.Container_Panel.Controls.Add(this.uLabel_ClaimSnm);
            this.Container_Panel.Controls.Add(this.tComboEditor_CustomerDivCd);
            this.Container_Panel.Controls.Add(this.ultraLabel30);
            this.Container_Panel.Controls.Add(this.ultraLabel51);
            this.Container_Panel.Controls.Add(this.ultraLabel48);
            this.Container_Panel.Controls.Add(this.tDateEdit_TransStopDate);
            this.Container_Panel.Controls.Add(this.ultraLabel44);
            this.Container_Panel.Controls.Add(this.ultraLabel47);
            this.Container_Panel.Controls.Add(this.ultraLabel45);
            this.Container_Panel.Controls.Add(this.ultraLabel46);
            this.Container_Panel.Controls.Add(this.ultraLabel41);
            this.Container_Panel.Controls.Add(this.tDateEdit_CustAgentChgDate);
            this.Container_Panel.Controls.Add(this.ultraLabel36);
            this.Container_Panel.Controls.Add(this.ultraLabel33);
            this.Container_Panel.Controls.Add(this.ultraLabel32);
            this.Container_Panel.Controls.Add(this.tComboEditor_AccRecDivCd);
            this.Container_Panel.Controls.Add(this.tComboEditor_DepoDelCode);
            this.Container_Panel.Controls.Add(this.tComboEditor_CreditMngCode);
            this.Container_Panel.Controls.Add(this.uButton_OldCustomerAgentNmGuide);
            this.Container_Panel.Controls.Add(this.ultraLabel31);
            this.Container_Panel.Controls.Add(this.tNedit_CollectSight);
            this.Container_Panel.Controls.Add(this.ultraLabel29);
            this.Container_Panel.Controls.Add(this.tComboEditor_CollectCond);
            this.Container_Panel.Controls.Add(this.ultraLabel27);
            this.Container_Panel.Controls.Add(this.tEdit_CustomerSnm);
            this.Container_Panel.Controls.Add(this.ultraLabel17);
            this.Container_Panel.Controls.Add(this.ultraLabel18);
            this.Container_Panel.Controls.Add(this.ultraLabel13);
            this.Container_Panel.Controls.Add(this.tComboEditor_ConsTaxLayMethod);
            this.Container_Panel.Controls.Add(this.ultraLabel6);
            this.Container_Panel.Controls.Add(this.ultraLabel1);
            this.Container_Panel.Controls.Add(this.ultraLabel19);
            this.Container_Panel.Controls.Add(this.tDateEdit_UpdateDateTime);
            this.Container_Panel.Controls.Add(this.tDateEdit_CreateDateTime);
            this.Container_Panel.Controls.Add(this.ultraLabel22);
            this.Container_Panel.Controls.Add(this.CustomerKindTitle_ULabel);
            this.Container_Panel.Controls.Add(this.uLabel_ClaimName2);
            this.Container_Panel.Controls.Add(this.tNedit_CustomerCode);
            this.Container_Panel.Controls.Add(this.uButton_StyleChange);
            this.Container_Panel.Controls.Add(this.uLabel_InputModeTitle);
            this.Container_Panel.Controls.Add(this.tComboEditor_CollectMoneyCode);
            this.Container_Panel.Controls.Add(this.tComboEditor_OutputNameCode);
            this.Container_Panel.Controls.Add(this.uLabel_CustomerClaimTitle);
            this.Container_Panel.Controls.Add(this.uButton_ClaimNameGuide);
            this.Container_Panel.Controls.Add(this.ultraLabel59);
            this.Container_Panel.Controls.Add(this.uLabel_CustomerNameTitle);
            this.Container_Panel.Controls.Add(this.SubInfo_UTabControl);
            this.Container_Panel.Controls.Add(this.uButton_BillCollecterNmGuide);
            this.Container_Panel.Controls.Add(this.uButton_CustomerAgentNmGuide);
            this.Container_Panel.Controls.Add(this.tEdit_BillCollecterNm);
            this.Container_Panel.Controls.Add(this.tEdit_CustomerAgentNm);
            this.Container_Panel.Controls.Add(this.BillCollecterNmTitle_ULabel);
            this.Container_Panel.Controls.Add(this.CustomerAgentNmTitle_ULabel);
            this.Container_Panel.Controls.Add(this.tNedit_CollectMoneyDay);
            this.Container_Panel.Controls.Add(this.CollectMoneyCodeTitle_ULabel);
            this.Container_Panel.Controls.Add(this.CollectMoneyDayTitle_ULabel);
            this.Container_Panel.Controls.Add(this.tNedit_TotalDay);
            this.Container_Panel.Controls.Add(this.TotalDayTitle_ULabel);
            this.Container_Panel.Controls.Add(this.ultraLabel35);
            this.Container_Panel.Controls.Add(this.ultraLabel34);
            this.Container_Panel.Controls.Add(this.ultraLabel56);
            this.Container_Panel.Controls.Add(this.ultraLabel10);
            this.Container_Panel.Controls.Add(this.ultraLabel11);
            this.Container_Panel.Controls.Add(this.ultraLabel12);
            this.Container_Panel.Controls.Add(this.tEdit_Kana);
            this.Container_Panel.Controls.Add(this.tEdit_Name2);
            this.Container_Panel.Controls.Add(this.tEdit_Name);
            this.Container_Panel.Controls.Add(this.tEdit_CustomerSubCode);
            this.Container_Panel.Controls.Add(this.uLabel_CustomerDetailsTitle);
            this.Container_Panel.Controls.Add(this.BusinessTypeCodeTitle_ULabel);
            this.Container_Panel.Controls.Add(this.JobTypeCodeTitle_ULabel);
            this.Container_Panel.Controls.Add(this.ultraLabel61);
            this.Container_Panel.Controls.Add(this.ultraLabel62);
            this.Container_Panel.Controls.Add(this.CustomerDetails_ULabel);
            gridBagConstraint1.Anchor = Infragistics.Win.Layout.AnchorType.TopLeft;
            this.ultraGridBagLayoutManager1.SetGridBagConstraint(this.Container_Panel, gridBagConstraint1);
            this.Container_Panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Container_Panel.Location = new System.Drawing.Point(0, 0);
            this.Container_Panel.Name = "Container_Panel";
            this.Container_Panel.Size = new System.Drawing.Size(1022, 632);
            this.Container_Panel.TabIndex = 0;
            // 
            // tEdit_JobTypeName
            // 
            appearance331.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_JobTypeName.ActiveAppearance = appearance331;
            appearance354.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_JobTypeName.Appearance = appearance354;
            this.tEdit_JobTypeName.AutoSelect = true;
            this.tEdit_JobTypeName.DataText = "";
            this.tEdit_JobTypeName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_JobTypeName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_JobTypeName.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_JobTypeName.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_JobTypeName.Location = new System.Drawing.Point(123, 390);
            this.tEdit_JobTypeName.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_JobTypeName.MaxLength = 4;
            this.tEdit_JobTypeName.Name = "tEdit_JobTypeName";
            this.tEdit_JobTypeName.Size = new System.Drawing.Size(128, 22);
            this.tEdit_JobTypeName.TabIndex = 1301;
            // 
            // uButton_JobTypeCodeGuide
            // 
            appearance37.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButton_JobTypeCodeGuide.Appearance = appearance37;
            this.uButton_JobTypeCodeGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.uButton_JobTypeCodeGuide.Location = new System.Drawing.Point(255, 388);
            this.uButton_JobTypeCodeGuide.Name = "uButton_JobTypeCodeGuide";
            this.uButton_JobTypeCodeGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_JobTypeCodeGuide.TabIndex = 1300;
            this.uButton_JobTypeCodeGuide.TabStop = false;
            this.uButton_JobTypeCodeGuide.Tag = "1";
            this.uButton_JobTypeCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_JobTypeCodeGuide.Click += new System.EventHandler(this.uButton_JobTypeCodeGuide_Click);
            // 
            // tEdit_SalesAreaNm
            // 
            appearance223.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesAreaNm.ActiveAppearance = appearance223;
            appearance224.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SalesAreaNm.Appearance = appearance224;
            this.tEdit_SalesAreaNm.AutoSelect = true;
            this.tEdit_SalesAreaNm.DataText = "";
            this.tEdit_SalesAreaNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesAreaNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SalesAreaNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SalesAreaNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SalesAreaNm.Location = new System.Drawing.Point(123, 417);
            this.tEdit_SalesAreaNm.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_SalesAreaNm.MaxLength = 4;
            this.tEdit_SalesAreaNm.Name = "tEdit_SalesAreaNm";
            this.tEdit_SalesAreaNm.Size = new System.Drawing.Size(128, 22);
            this.tEdit_SalesAreaNm.TabIndex = 1299;
            // 
            // uButton_SalesAreaCdGuide
            // 
            this.uButton_SalesAreaCdGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.uButton_SalesAreaCdGuide.Location = new System.Drawing.Point(255, 415);
            this.uButton_SalesAreaCdGuide.Name = "uButton_SalesAreaCdGuide";
            this.uButton_SalesAreaCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesAreaCdGuide.TabIndex = 1298;
            this.uButton_SalesAreaCdGuide.TabStop = false;
            this.uButton_SalesAreaCdGuide.Tag = "1";
            this.uButton_SalesAreaCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesAreaCdGuide.Click += new System.EventHandler(this.uButton_SalesAreaCdGuide_Click);
            // 
            // tEdit_BusinessTypeNm
            // 
            appearance183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_BusinessTypeNm.ActiveAppearance = appearance183;
            appearance355.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_BusinessTypeNm.Appearance = appearance355;
            this.tEdit_BusinessTypeNm.AutoSelect = true;
            this.tEdit_BusinessTypeNm.DataText = "";
            this.tEdit_BusinessTypeNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_BusinessTypeNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_BusinessTypeNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_BusinessTypeNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_BusinessTypeNm.Location = new System.Drawing.Point(123, 361);
            this.tEdit_BusinessTypeNm.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_BusinessTypeNm.MaxLength = 4;
            this.tEdit_BusinessTypeNm.Name = "tEdit_BusinessTypeNm";
            this.tEdit_BusinessTypeNm.Size = new System.Drawing.Size(128, 22);
            this.tEdit_BusinessTypeNm.TabIndex = 1297;
            // 
            // uButton_BusinessTypeCdGuide
            // 
            this.uButton_BusinessTypeCdGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.uButton_BusinessTypeCdGuide.Location = new System.Drawing.Point(255, 359);
            this.uButton_BusinessTypeCdGuide.Name = "uButton_BusinessTypeCdGuide";
            this.uButton_BusinessTypeCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_BusinessTypeCdGuide.TabIndex = 1296;
            this.uButton_BusinessTypeCdGuide.TabStop = false;
            this.uButton_BusinessTypeCdGuide.Tag = "1";
            this.uButton_BusinessTypeCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_BusinessTypeCdGuide.Click += new System.EventHandler(this.uButton_BusinessTypeCdGuide_Click);
            // 
            // tEdit_HonorificTitle
            // 
            appearance244.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_HonorificTitle.ActiveAppearance = appearance244;
            appearance284.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_HonorificTitle.Appearance = appearance284;
            this.tEdit_HonorificTitle.AutoSelect = true;
            this.tEdit_HonorificTitle.DataText = "";
            this.tEdit_HonorificTitle.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_HonorificTitle.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_HonorificTitle.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_HonorificTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_HonorificTitle.Location = new System.Drawing.Point(123, 151);
            this.tEdit_HonorificTitle.MaxLength = 4;
            this.tEdit_HonorificTitle.Name = "tEdit_HonorificTitle";
            this.tEdit_HonorificTitle.Size = new System.Drawing.Size(73, 22);
            this.tEdit_HonorificTitle.TabIndex = 1295;
            // 
            // uLabel_SubInfo8Title
            // 
            appearance158.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance158.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance158.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance158.ForeColor = System.Drawing.Color.White;
            appearance158.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance158.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance158.TextHAlignAsString = "Center";
            appearance158.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo8Title.Appearance = appearance158;
            this.uLabel_SubInfo8Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo8Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo8Title.Location = new System.Drawing.Point(486, 35);
            this.uLabel_SubInfo8Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo8Title.Name = "uLabel_SubInfo8Title";
            this.uLabel_SubInfo8Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo8Title.TabIndex = 1294;
            this.uLabel_SubInfo8Title.Text = "ÉÅÉÇèÓïÒ";
            this.uLabel_SubInfo8Title.Visible = false;
            // 
            // uLabel_SubInfo7Title
            // 
            appearance201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance201.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance201.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance201.ForeColor = System.Drawing.Color.White;
            appearance201.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance201.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance201.TextHAlignAsString = "Center";
            appearance201.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo7Title.Appearance = appearance201;
            this.uLabel_SubInfo7Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo7Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo7Title.Location = new System.Drawing.Point(461, 35);
            this.uLabel_SubInfo7Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo7Title.Name = "uLabel_SubInfo7Title";
            this.uLabel_SubInfo7Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo7Title.TabIndex = 1294;
            this.uLabel_SubInfo7Title.Text = "ÉIÉìÉâÉCÉìèÓïÒ";
            this.uLabel_SubInfo7Title.Visible = false;
            // 
            // uLabel_SubInfo6Title
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance78.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance78.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance78.ForeColor = System.Drawing.Color.White;
            appearance78.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance78.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance78.TextHAlignAsString = "Center";
            appearance78.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo6Title.Appearance = appearance78;
            this.uLabel_SubInfo6Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo6Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo6Title.Location = new System.Drawing.Point(436, 35);
            this.uLabel_SubInfo6Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo6Title.Name = "uLabel_SubInfo6Title";
            this.uLabel_SubInfo6Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo6Title.TabIndex = 1294;
            this.uLabel_SubInfo6Title.Text = "ì`ï[ÅEêøãÅèëèÓïÒ";
            this.uLabel_SubInfo6Title.Visible = false;
            // 
            // tEdit_CustWarehouseCd
            // 
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustWarehouseCd.ActiveAppearance = appearance88;
            appearance289.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustWarehouseCd.Appearance = appearance289;
            this.tEdit_CustWarehouseCd.AutoSelect = true;
            this.tEdit_CustWarehouseCd.DataText = "";
            this.tEdit_CustWarehouseCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustWarehouseCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustWarehouseCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustWarehouseCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_CustWarehouseCd.Location = new System.Drawing.Point(396, 333);
            this.tEdit_CustWarehouseCd.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_CustWarehouseCd.MaxLength = 30;
            this.tEdit_CustWarehouseCd.Name = "tEdit_CustWarehouseCd";
            this.tEdit_CustWarehouseCd.Size = new System.Drawing.Size(128, 22);
            this.tEdit_CustWarehouseCd.TabIndex = 1291;
            // 
            // uButton_CustWarehouseGuide
            // 
            this.uButton_CustWarehouseGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustWarehouseGuide.Location = new System.Drawing.Point(527, 332);
            this.uButton_CustWarehouseGuide.Margin = new System.Windows.Forms.Padding(0);
            this.uButton_CustWarehouseGuide.Name = "uButton_CustWarehouseGuide";
            this.uButton_CustWarehouseGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustWarehouseGuide.TabIndex = 1292;
            this.toolTip1.SetToolTip(this.uButton_CustWarehouseGuide, "ëqå…ÉKÉCÉh");
            this.uButton_CustWarehouseGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustWarehouseGuide.Click += new System.EventHandler(this.uButton_CustWarehouseGuide_Click);
            // 
            // ultraLabel50
            // 
            appearance150.TextHAlignAsString = "Center";
            appearance150.TextVAlignAsString = "Middle";
            this.ultraLabel50.Appearance = appearance150;
            this.ultraLabel50.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel50.Location = new System.Drawing.Point(319, 333);
            this.ultraLabel50.Name = "ultraLabel50";
            this.ultraLabel50.Size = new System.Drawing.Size(66, 22);
            this.ultraLabel50.TabIndex = 1293;
            this.ultraLabel50.Text = "óDêÊëqå…";
            // 
            // tComboEditor_CarMngDivCd
            // 
            appearance140.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CarMngDivCd.ActiveAppearance = appearance140;
            appearance123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance123.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CarMngDivCd.Appearance = appearance123;
            this.tComboEditor_CarMngDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CarMngDivCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CarMngDivCd.ItemAppearance = appearance141;
            this.tComboEditor_CarMngDivCd.Location = new System.Drawing.Point(396, 277);
            this.tComboEditor_CarMngDivCd.Name = "tComboEditor_CarMngDivCd";
            this.tComboEditor_CarMngDivCd.Size = new System.Drawing.Size(155, 22);
            this.tComboEditor_CarMngDivCd.TabIndex = 1290;
            this.tComboEditor_CarMngDivCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CarMngDivCd_SelectionChangeCommitted);
            // 
            // ultraLabel49
            // 
            appearance132.TextHAlignAsString = "Center";
            appearance132.TextVAlignAsString = "Middle";
            this.ultraLabel49.Appearance = appearance132;
            this.ultraLabel49.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel49.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel49.Location = new System.Drawing.Point(307, 276);
            this.ultraLabel49.Name = "ultraLabel49";
            this.ultraLabel49.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel49.TabIndex = 1289;
            this.ultraLabel49.Text = "é‘Áqä«óù";
            // 
            // uButton_ClaimSectionGuide
            // 
            this.uButton_ClaimSectionGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_ClaimSectionGuide.Location = new System.Drawing.Point(976, 31);
            this.uButton_ClaimSectionGuide.Name = "uButton_ClaimSectionGuide";
            this.uButton_ClaimSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_ClaimSectionGuide.TabIndex = 1288;
            this.uButton_ClaimSectionGuide.Tag = "0";
            this.toolTip1.SetToolTip(this.uButton_ClaimSectionGuide, "ãíì_ÉKÉCÉh");
            this.uButton_ClaimSectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ClaimSectionGuide.Click += new System.EventHandler(this.SectionNmGuide_uButton_Click);
            // 
            // tEdit_ClaimSectionCode
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_ClaimSectionCode.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance86.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_ClaimSectionCode.Appearance = appearance86;
            this.tEdit_ClaimSectionCode.AutoSelect = true;
            this.tEdit_ClaimSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_ClaimSectionCode.DataText = "";
            this.tEdit_ClaimSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_ClaimSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_ClaimSectionCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_ClaimSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_ClaimSectionCode.Location = new System.Drawing.Point(680, 32);
            this.tEdit_ClaimSectionCode.MaxLength = 30;
            this.tEdit_ClaimSectionCode.Name = "tEdit_ClaimSectionCode";
            this.tEdit_ClaimSectionCode.Size = new System.Drawing.Size(293, 22);
            this.tEdit_ClaimSectionCode.TabIndex = 1287;
            // 
            // ultraLabel37
            // 
            appearance87.TextHAlignAsString = "Center";
            appearance87.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance87;
            this.ultraLabel37.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel37.Location = new System.Drawing.Point(589, 32);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel37.TabIndex = 1286;
            this.ultraLabel37.Text = "êøãÅãíì_";
            // 
            // uLabel_SubInfo0Title
            // 
            appearance156.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance156.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance156.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance156.ForeColor = System.Drawing.Color.White;
            appearance156.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance156.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance156.TextHAlignAsString = "Center";
            appearance156.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo0Title.Appearance = appearance156;
            this.uLabel_SubInfo0Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo0Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo0Title.Location = new System.Drawing.Point(336, 35);
            this.uLabel_SubInfo0Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo0Title.Name = "uLabel_SubInfo0Title";
            this.uLabel_SubInfo0Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo0Title.TabIndex = 1216;
            this.uLabel_SubInfo0Title.Text = "òAóçêÊèÓïÒ";
            this.uLabel_SubInfo0Title.Visible = false;
            // 
            // uLabel_SubInfo5Title
            // 
            appearance157.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance157.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance157.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance157.ForeColor = System.Drawing.Color.White;
            appearance157.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance157.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance157.TextHAlignAsString = "Center";
            appearance157.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo5Title.Appearance = appearance157;
            this.uLabel_SubInfo5Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo5Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo5Title.Location = new System.Drawing.Point(361, 35);
            this.uLabel_SubInfo5Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo5Title.Name = "uLabel_SubInfo5Title";
            this.uLabel_SubInfo5Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo5Title.TabIndex = 1215;
            this.uLabel_SubInfo5Title.Text = "å˚ç¿èÓïÒ";
            this.uLabel_SubInfo5Title.Visible = false;
            // 
            // uLabel_SubInfo4Title
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance61.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo4Title.Appearance = appearance61;
            this.uLabel_SubInfo4Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo4Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo4Title.Location = new System.Drawing.Point(411, 35);
            this.uLabel_SubInfo4Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo4Title.Name = "uLabel_SubInfo4Title";
            this.uLabel_SubInfo4Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo4Title.TabIndex = 1136;
            this.uLabel_SubInfo4Title.Text = "ÇdÉÅÅbÉãèÓïÒ";
            this.uLabel_SubInfo4Title.Visible = false;
            // 
            // tComboEditor_CorporateDivCode
            // 
            appearance194.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CorporateDivCode.ActiveAppearance = appearance194;
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance73.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CorporateDivCode.Appearance = appearance73;
            this.tComboEditor_CorporateDivCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CorporateDivCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance195.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CorporateDivCode.ItemAppearance = appearance195;
            this.tComboEditor_CorporateDivCode.Location = new System.Drawing.Point(123, 305);
            this.tComboEditor_CorporateDivCode.Name = "tComboEditor_CorporateDivCode";
            this.tComboEditor_CorporateDivCode.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_CorporateDivCode.TabIndex = 401;
            this.tComboEditor_CorporateDivCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CorporateDivCode_SelectionChangeCommitted);
            // 
            // CorporateDivCodeTitle_ULabel
            // 
            appearance196.TextHAlignAsString = "Center";
            appearance196.TextVAlignAsString = "Middle";
            this.CorporateDivCodeTitle_ULabel.Appearance = appearance196;
            this.CorporateDivCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CorporateDivCodeTitle_ULabel.Location = new System.Drawing.Point(30, 305);
            this.CorporateDivCodeTitle_ULabel.Name = "CorporateDivCodeTitle_ULabel";
            this.CorporateDivCodeTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.CorporateDivCodeTitle_ULabel.TabIndex = 504;
            this.CorporateDivCodeTitle_ULabel.Text = "å¬êlÅEñ@êl";
            // 
            // tNedit_CustAnalysCode1
            // 
            appearance250.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode1.ActiveAppearance = appearance250;
            appearance251.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance251.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode1.Appearance = appearance251;
            this.tNedit_CustAnalysCode1.AutoSelect = true;
            this.tNedit_CustAnalysCode1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode1.DataText = "";
            this.tNedit_CustAnalysCode1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode1.Location = new System.Drawing.Point(348, 417);
            this.tNedit_CustAnalysCode1.MaxLength = 3;
            this.tNedit_CustAnalysCode1.Name = "tNedit_CustAnalysCode1";
            this.tNedit_CustAnalysCode1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode1.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode1.TabIndex = 405;
            // 
            // ultraLabel28
            // 
            appearance164.TextHAlignAsString = "Center";
            appearance164.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance164;
            this.ultraLabel28.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel28.Location = new System.Drawing.Point(31, 333);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel28.TabIndex = 1220;
            this.ultraLabel28.Text = "ìæà”êÊëÆê´";
            // 
            // CustAnalysCodeTitle_ULabel
            // 
            appearance263.TextHAlignAsString = "Center";
            appearance263.TextVAlignAsString = "Middle";
            this.CustAnalysCodeTitle_ULabel.Appearance = appearance263;
            this.CustAnalysCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustAnalysCodeTitle_ULabel.Location = new System.Drawing.Point(316, 392);
            this.CustAnalysCodeTitle_ULabel.Name = "CustAnalysCodeTitle_ULabel";
            this.CustAnalysCodeTitle_ULabel.Size = new System.Drawing.Size(77, 22);
            this.CustAnalysCodeTitle_ULabel.TabIndex = 357;
            this.CustAnalysCodeTitle_ULabel.Text = "ï™êÕÉRÅ[Éh";
            // 
            // tComboEditor_CustomerAttributeDiv
            // 
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerAttributeDiv.ActiveAppearance = appearance162;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance74.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CustomerAttributeDiv.Appearance = appearance74;
            this.tComboEditor_CustomerAttributeDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CustomerAttributeDiv.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerAttributeDiv.ItemAppearance = appearance163;
            this.tComboEditor_CustomerAttributeDiv.Location = new System.Drawing.Point(123, 333);
            this.tComboEditor_CustomerAttributeDiv.Name = "tComboEditor_CustomerAttributeDiv";
            this.tComboEditor_CustomerAttributeDiv.Size = new System.Drawing.Size(160, 22);
            this.tComboEditor_CustomerAttributeDiv.TabIndex = 1219;
            this.tComboEditor_CustomerAttributeDiv.SelectionChanged += new System.EventHandler(this.tComboEditor_CustomerAttributeDiv_SelectionChanged);
            this.tComboEditor_CustomerAttributeDiv.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CustomerAttributeDiv_SelectionChangeCommitted);
            this.tComboEditor_CustomerAttributeDiv.ValueChanged += new System.EventHandler(this.tComboEditor_CustomerAttributeDiv_ValueChanged);
            // 
            // uLabel_SubInfo2Title
            // 
            appearance160.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance160.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance160.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance160.ForeColor = System.Drawing.Color.White;
            appearance160.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance160.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance160.TextHAlignAsString = "Center";
            appearance160.TextVAlignAsString = "Middle";
            this.uLabel_SubInfo2Title.Appearance = appearance160;
            this.uLabel_SubInfo2Title.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_SubInfo2Title.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_SubInfo2Title.Location = new System.Drawing.Point(386, 35);
            this.uLabel_SubInfo2Title.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_SubInfo2Title.Name = "uLabel_SubInfo2Title";
            this.uLabel_SubInfo2Title.Size = new System.Drawing.Size(25, 145);
            this.uLabel_SubInfo2Title.TabIndex = 1134;
            this.uLabel_SubInfo2Title.Text = "îıçlèÓïÒ";
            this.uLabel_SubInfo2Title.Visible = false;
            // 
            // tNedit_CustAnalysCode2
            // 
            appearance259.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode2.ActiveAppearance = appearance259;
            appearance260.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance260.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode2.Appearance = appearance260;
            this.tNedit_CustAnalysCode2.AutoSelect = true;
            this.tNedit_CustAnalysCode2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode2.DataText = "";
            this.tNedit_CustAnalysCode2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode2.Location = new System.Drawing.Point(382, 417);
            this.tNedit_CustAnalysCode2.MaxLength = 3;
            this.tNedit_CustAnalysCode2.Name = "tNedit_CustAnalysCode2";
            this.tNedit_CustAnalysCode2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode2.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode2.TabIndex = 406;
            // 
            // tNedit_CustAnalysCode4
            // 
            appearance257.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode4.ActiveAppearance = appearance257;
            appearance258.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance258.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode4.Appearance = appearance258;
            this.tNedit_CustAnalysCode4.AutoSelect = true;
            this.tNedit_CustAnalysCode4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode4.DataText = "";
            this.tNedit_CustAnalysCode4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode4.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode4.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode4.Location = new System.Drawing.Point(450, 417);
            this.tNedit_CustAnalysCode4.MaxLength = 3;
            this.tNedit_CustAnalysCode4.Name = "tNedit_CustAnalysCode4";
            this.tNedit_CustAnalysCode4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode4.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode4.TabIndex = 408;
            // 
            // ultraLabel60
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel60.Appearance = appearance80;
            this.ultraLabel60.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel60.Location = new System.Drawing.Point(708, 210);
            this.ultraLabel60.Name = "ultraLabel60";
            this.ultraLabel60.Size = new System.Drawing.Size(62, 22);
            this.ultraLabel60.TabIndex = 1285;
            this.ultraLabel60.Text = "ì˙Å`í˜ì˙";
            // 
            // tNedit_CustAnalysCode6
            // 
            appearance255.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode6.ActiveAppearance = appearance255;
            appearance256.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance256.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode6.Appearance = appearance256;
            this.tNedit_CustAnalysCode6.AutoSelect = true;
            this.tNedit_CustAnalysCode6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode6.DataText = "";
            this.tNedit_CustAnalysCode6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode6.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode6.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode6.Location = new System.Drawing.Point(518, 417);
            this.tNedit_CustAnalysCode6.MaxLength = 3;
            this.tNedit_CustAnalysCode6.Name = "tNedit_CustAnalysCode6";
            this.tNedit_CustAnalysCode6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode6.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode6.TabIndex = 410;
            // 
            // tNedit_NTimeCalcStDate
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_NTimeCalcStDate.ActiveAppearance = appearance81;
            appearance82.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance82.TextHAlignAsString = "Right";
            this.tNedit_NTimeCalcStDate.Appearance = appearance82;
            this.tNedit_NTimeCalcStDate.AutoSelect = true;
            this.tNedit_NTimeCalcStDate.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_NTimeCalcStDate.DataText = "";
            this.tNedit_NTimeCalcStDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_NTimeCalcStDate.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_NTimeCalcStDate.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_NTimeCalcStDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_NTimeCalcStDate.Location = new System.Drawing.Point(680, 209);
            this.tNedit_NTimeCalcStDate.MaxLength = 2;
            this.tNedit_NTimeCalcStDate.Name = "tNedit_NTimeCalcStDate";
            this.tNedit_NTimeCalcStDate.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_NTimeCalcStDate.Size = new System.Drawing.Size(25, 22);
            this.tNedit_NTimeCalcStDate.TabIndex = 1284;
            // 
            // tNedit_CustAnalysCode3
            // 
            appearance252.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode3.ActiveAppearance = appearance252;
            appearance253.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance253.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode3.Appearance = appearance253;
            this.tNedit_CustAnalysCode3.AutoSelect = true;
            this.tNedit_CustAnalysCode3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode3.DataText = "";
            this.tNedit_CustAnalysCode3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode3.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode3.Location = new System.Drawing.Point(416, 417);
            this.tNedit_CustAnalysCode3.MaxLength = 3;
            this.tNedit_CustAnalysCode3.Name = "tNedit_CustAnalysCode3";
            this.tNedit_CustAnalysCode3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode3.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode3.TabIndex = 407;
            // 
            // ultraLabel58
            // 
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel58.Appearance = appearance83;
            this.ultraLabel58.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(590, 209);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel58.TabIndex = 1283;
            this.ultraLabel58.Text = "éüâÒä®íË";
            // 
            // tNedit_CustAnalysCode5
            // 
            appearance248.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustAnalysCode5.ActiveAppearance = appearance248;
            appearance249.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance249.TextHAlignAsString = "Right";
            this.tNedit_CustAnalysCode5.Appearance = appearance249;
            this.tNedit_CustAnalysCode5.AutoSelect = true;
            this.tNedit_CustAnalysCode5.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustAnalysCode5.DataText = "";
            this.tNedit_CustAnalysCode5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustAnalysCode5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CustAnalysCode5.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustAnalysCode5.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustAnalysCode5.Location = new System.Drawing.Point(484, 417);
            this.tNedit_CustAnalysCode5.MaxLength = 3;
            this.tNedit_CustAnalysCode5.Name = "tNedit_CustAnalysCode5";
            this.tNedit_CustAnalysCode5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustAnalysCode5.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CustAnalysCode5.TabIndex = 409;
            // 
            // uLabel_ClaimName1
            // 
            appearance84.BackColor = System.Drawing.Color.Gainsboro;
            appearance84.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance84.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.uLabel_ClaimName1.Appearance = appearance84;
            this.uLabel_ClaimName1.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ClaimName1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ClaimName1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_ClaimName1.Location = new System.Drawing.Point(680, 82);
            this.uLabel_ClaimName1.Name = "uLabel_ClaimName1";
            this.uLabel_ClaimName1.Size = new System.Drawing.Size(318, 22);
            this.uLabel_ClaimName1.TabIndex = 1282;
            this.uLabel_ClaimName1.WrapText = false;
            // 
            // uButton_MngSectionNmGuide
            // 
            this.uButton_MngSectionNmGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MngSectionNmGuide.Location = new System.Drawing.Point(527, 192);
            this.uButton_MngSectionNmGuide.Name = "uButton_MngSectionNmGuide";
            this.uButton_MngSectionNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_MngSectionNmGuide.TabIndex = 1281;
            this.uButton_MngSectionNmGuide.Tag = "0";
            this.toolTip1.SetToolTip(this.uButton_MngSectionNmGuide, "ãíì_ÉKÉCÉh");
            this.uButton_MngSectionNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MngSectionNmGuide.Click += new System.EventHandler(this.SectionNmGuide_uButton_Click);
            // 
            // tEdit_MngSectionNm
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MngSectionNm.ActiveAppearance = appearance111;
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance112.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_MngSectionNm.Appearance = appearance112;
            this.tEdit_MngSectionNm.AutoSelect = true;
            this.tEdit_MngSectionNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MngSectionNm.DataText = "";
            this.tEdit_MngSectionNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MngSectionNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MngSectionNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MngSectionNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MngSectionNm.Location = new System.Drawing.Point(123, 192);
            this.tEdit_MngSectionNm.MaxLength = 30;
            this.tEdit_MngSectionNm.Name = "tEdit_MngSectionNm";
            this.tEdit_MngSectionNm.Size = new System.Drawing.Size(403, 22);
            this.tEdit_MngSectionNm.TabIndex = 1280;
            // 
            // ultraLabel57
            // 
            appearance114.TextHAlignAsString = "Center";
            appearance114.TextVAlignAsString = "Middle";
            this.ultraLabel57.Appearance = appearance114;
            this.ultraLabel57.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(30, 192);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel57.TabIndex = 1279;
            this.ultraLabel57.Text = "ä«óùãíì_";
            // 
            // tEdit_OldCustomerAgentNm
            // 
            appearance134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OldCustomerAgentNm.ActiveAppearance = appearance134;
            appearance285.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OldCustomerAgentNm.Appearance = appearance285;
            this.tEdit_OldCustomerAgentNm.AutoSelect = true;
            this.tEdit_OldCustomerAgentNm.DataText = "";
            this.tEdit_OldCustomerAgentNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OldCustomerAgentNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_OldCustomerAgentNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OldCustomerAgentNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OldCustomerAgentNm.Location = new System.Drawing.Point(396, 220);
            this.tEdit_OldCustomerAgentNm.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_OldCustomerAgentNm.MaxLength = 30;
            this.tEdit_OldCustomerAgentNm.Name = "tEdit_OldCustomerAgentNm";
            this.tEdit_OldCustomerAgentNm.Size = new System.Drawing.Size(128, 22);
            this.tEdit_OldCustomerAgentNm.TabIndex = 1225;
            // 
            // tNedit_ClaimCode
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_ClaimCode.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance90.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance90.TextHAlignAsString = "Right";
            this.tNedit_ClaimCode.Appearance = appearance90;
            this.tNedit_ClaimCode.AutoSelect = true;
            this.tNedit_ClaimCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_ClaimCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_ClaimCode.DataText = "";
            this.tNedit_ClaimCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_ClaimCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_ClaimCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_ClaimCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_ClaimCode.Location = new System.Drawing.Point(680, 57);
            this.tNedit_ClaimCode.MaxLength = 9;
            this.tNedit_ClaimCode.Name = "tNedit_ClaimCode";
            this.tNedit_ClaimCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_ClaimCode.Size = new System.Drawing.Size(73, 22);
            this.tNedit_ClaimCode.TabIndex = 1278;
            // 
            // ultraLabel55
            // 
            appearance91.TextHAlignAsString = "Center";
            appearance91.TextVAlignAsString = "Middle";
            this.ultraLabel55.Appearance = appearance91;
            this.ultraLabel55.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel55.Location = new System.Drawing.Point(589, 59);
            this.ultraLabel55.Name = "ultraLabel55";
            this.ultraLabel55.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel55.TabIndex = 1277;
            this.ultraLabel55.Text = "êøãÅêÊÉRÅ[Éh";
            // 
            // tNedit_SalesCnsTaxFrcProcCd
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance92.TextHAlignAsString = "Right";
            this.tNedit_SalesCnsTaxFrcProcCd.ActiveAppearance = appearance92;
            appearance93.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance93.TextHAlignAsString = "Right";
            this.tNedit_SalesCnsTaxFrcProcCd.Appearance = appearance93;
            this.tNedit_SalesCnsTaxFrcProcCd.AutoSelect = true;
            this.tNedit_SalesCnsTaxFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesCnsTaxFrcProcCd.DataText = "";
            this.tNedit_SalesCnsTaxFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesCnsTaxFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SalesCnsTaxFrcProcCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SalesCnsTaxFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesCnsTaxFrcProcCd.Location = new System.Drawing.Point(877, 414);
            this.tNedit_SalesCnsTaxFrcProcCd.MaxLength = 8;
            this.tNedit_SalesCnsTaxFrcProcCd.Name = "tNedit_SalesCnsTaxFrcProcCd";
            this.tNedit_SalesCnsTaxFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesCnsTaxFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_SalesCnsTaxFrcProcCd.TabIndex = 1276;
            // 
            // tNedit_SalesMoneyFrcProcCd
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.tNedit_SalesMoneyFrcProcCd.ActiveAppearance = appearance94;
            appearance95.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_SalesMoneyFrcProcCd.Appearance = appearance95;
            this.tNedit_SalesMoneyFrcProcCd.AutoSelect = true;
            this.tNedit_SalesMoneyFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesMoneyFrcProcCd.DataText = "";
            this.tNedit_SalesMoneyFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesMoneyFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SalesMoneyFrcProcCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SalesMoneyFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesMoneyFrcProcCd.Location = new System.Drawing.Point(877, 378);
            this.tNedit_SalesMoneyFrcProcCd.MaxLength = 8;
            this.tNedit_SalesMoneyFrcProcCd.Name = "tNedit_SalesMoneyFrcProcCd";
            this.tNedit_SalesMoneyFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesMoneyFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_SalesMoneyFrcProcCd.TabIndex = 1275;
            // 
            // tNedit_SalesUnPrcFrcProcCd
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.TextHAlignAsString = "Right";
            this.tNedit_SalesUnPrcFrcProcCd.ActiveAppearance = appearance96;
            appearance97.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance97.TextHAlignAsString = "Right";
            this.tNedit_SalesUnPrcFrcProcCd.Appearance = appearance97;
            this.tNedit_SalesUnPrcFrcProcCd.AutoSelect = true;
            this.tNedit_SalesUnPrcFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesUnPrcFrcProcCd.DataText = "";
            this.tNedit_SalesUnPrcFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesUnPrcFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_SalesUnPrcFrcProcCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SalesUnPrcFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesUnPrcFrcProcCd.Location = new System.Drawing.Point(877, 342);
            this.tNedit_SalesUnPrcFrcProcCd.MaxLength = 8;
            this.tNedit_SalesUnPrcFrcProcCd.Name = "tNedit_SalesUnPrcFrcProcCd";
            this.tNedit_SalesUnPrcFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SalesUnPrcFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_SalesUnPrcFrcProcCd.TabIndex = 1274;
            // 
            // uButton_SalesCnsTaxFrcProcCdGuide
            // 
            this.uButton_SalesCnsTaxFrcProcCdGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesCnsTaxFrcProcCdGuide.Location = new System.Drawing.Point(946, 412);
            this.uButton_SalesCnsTaxFrcProcCdGuide.Name = "uButton_SalesCnsTaxFrcProcCdGuide";
            this.uButton_SalesCnsTaxFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesCnsTaxFrcProcCdGuide.TabIndex = 1273;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Tag = "1";
            this.toolTip1.SetToolTip(this.uButton_SalesCnsTaxFrcProcCdGuide, "í[êîèàóùÉKÉCÉh");
            this.uButton_SalesCnsTaxFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // uButton_SalesMoneyFrcProcCdGuide
            // 
            this.uButton_SalesMoneyFrcProcCdGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesMoneyFrcProcCdGuide.Location = new System.Drawing.Point(946, 377);
            this.uButton_SalesMoneyFrcProcCdGuide.Name = "uButton_SalesMoneyFrcProcCdGuide";
            this.uButton_SalesMoneyFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesMoneyFrcProcCdGuide.TabIndex = 1272;
            this.uButton_SalesMoneyFrcProcCdGuide.Tag = "0";
            this.toolTip1.SetToolTip(this.uButton_SalesMoneyFrcProcCdGuide, "í[êîèàóùÉKÉCÉh");
            this.uButton_SalesMoneyFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesMoneyFrcProcCdGuide.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // uButton_SalesUnPrcFrcProcCdGuide
            // 
            this.uButton_SalesUnPrcFrcProcCdGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesUnPrcFrcProcCdGuide.Location = new System.Drawing.Point(946, 341);
            this.uButton_SalesUnPrcFrcProcCdGuide.Name = "uButton_SalesUnPrcFrcProcCdGuide";
            this.uButton_SalesUnPrcFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesUnPrcFrcProcCdGuide.TabIndex = 1271;
            this.uButton_SalesUnPrcFrcProcCdGuide.Tag = "2";
            this.toolTip1.SetToolTip(this.uButton_SalesUnPrcFrcProcCdGuide, "í[êîèàóùÉKÉCÉh");
            this.uButton_SalesUnPrcFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesUnPrcFrcProcCdGuide.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraLabel54
            // 
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.ultraLabel54.Appearance = appearance98;
            this.ultraLabel54.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel54.Location = new System.Drawing.Point(591, 313);
            this.ultraLabel54.Name = "ultraLabel54";
            this.ultraLabel54.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel54.TabIndex = 1270;
            this.ultraLabel54.Text = "éQè∆ãÊï™";
            // 
            // ultraLabel52
            // 
            appearance99.TextHAlignAsString = "Center";
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel52.Appearance = appearance99;
            this.ultraLabel52.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel52.Location = new System.Drawing.Point(591, 295);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel52.TabIndex = 1269;
            this.ultraLabel52.Text = "ì]â≈ï˚éÆ";
            // 
            // tComboEditor_CustCTaXLayRefCd
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustCTaXLayRefCd.ActiveAppearance = appearance100;
            appearance142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance142.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CustCTaXLayRefCd.Appearance = appearance142;
            this.tComboEditor_CustCTaXLayRefCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CustCTaXLayRefCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_CustCTaXLayRefCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustCTaXLayRefCd.ItemAppearance = appearance101;
            this.tComboEditor_CustCTaXLayRefCd.Location = new System.Drawing.Point(680, 303);
            this.tComboEditor_CustCTaXLayRefCd.MaxDropDownItems = 18;
            this.tComboEditor_CustCTaXLayRefCd.Name = "tComboEditor_CustCTaXLayRefCd";
            this.tComboEditor_CustCTaXLayRefCd.Size = new System.Drawing.Size(125, 22);
            this.tComboEditor_CustCTaXLayRefCd.TabIndex = 1268;
            this.tComboEditor_CustCTaXLayRefCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CustCTaXLayRefCd_SelectionChangeCommitted);
            // 
            // ultraLabel53
            // 
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel53.Appearance = appearance102;
            this.ultraLabel53.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel53.Location = new System.Drawing.Point(590, 130);
            this.ultraLabel53.Name = "ultraLabel53";
            this.ultraLabel53.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel53.TabIndex = 1267;
            this.ultraLabel53.Text = "êøãÅêÊó™èÃ";
            // 
            // uLabel_ClaimSnm
            // 
            appearance103.BackColor = System.Drawing.Color.Gainsboro;
            appearance103.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance103.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance103.TextHAlignAsString = "Left";
            appearance103.TextVAlignAsString = "Middle";
            this.uLabel_ClaimSnm.Appearance = appearance103;
            this.uLabel_ClaimSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ClaimSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ClaimSnm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_ClaimSnm.Location = new System.Drawing.Point(680, 130);
            this.uLabel_ClaimSnm.Name = "uLabel_ClaimSnm";
            this.uLabel_ClaimSnm.Size = new System.Drawing.Size(318, 22);
            this.uLabel_ClaimSnm.TabIndex = 1266;
            this.uLabel_ClaimSnm.WrapText = false;
            // 
            // tComboEditor_CustomerDivCd
            // 
            appearance107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerDivCd.ActiveAppearance = appearance107;
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance79.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CustomerDivCd.Appearance = appearance79;
            this.tComboEditor_CustomerDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CustomerDivCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CustomerDivCd.ItemAppearance = appearance108;
            this.tComboEditor_CustomerDivCd.Location = new System.Drawing.Point(396, 305);
            this.tComboEditor_CustomerDivCd.Name = "tComboEditor_CustomerDivCd";
            this.tComboEditor_CustomerDivCd.Size = new System.Drawing.Size(155, 22);
            this.tComboEditor_CustomerDivCd.TabIndex = 1263;
            this.tComboEditor_CustomerDivCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CustomerDivCd_SelectionChangeCommitted);
            // 
            // ultraLabel30
            // 
            appearance109.TextHAlignAsString = "Center";
            appearance109.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance109;
            this.ultraLabel30.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel30.Location = new System.Drawing.Point(909, 192);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(55, 20);
            this.ultraLabel30.TabIndex = 1262;
            this.ultraLabel30.Text = "ÉTÉCÉg";
            // 
            // ultraLabel51
            // 
            appearance110.TextHAlignAsString = "Center";
            appearance110.TextVAlignAsString = "Middle";
            this.ultraLabel51.Appearance = appearance110;
            this.ultraLabel51.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel51.Location = new System.Drawing.Point(910, 176);
            this.ultraLabel51.Name = "ultraLabel51";
            this.ultraLabel51.Size = new System.Drawing.Size(55, 20);
            this.ultraLabel51.TabIndex = 1261;
            this.ultraLabel51.Text = "âÒé˚";
            // 
            // ultraLabel48
            // 
            appearance115.TextHAlignAsString = "Center";
            appearance115.TextVAlignAsString = "Middle";
            this.ultraLabel48.Appearance = appearance115;
            this.ultraLabel48.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel48.Location = new System.Drawing.Point(30, 277);
            this.ultraLabel48.Name = "ultraLabel48";
            this.ultraLabel48.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel48.TabIndex = 1257;
            this.ultraLabel48.Text = "éÊà¯íÜé~ì˙";
            // 
            // tDateEdit_TransStopDate
            // 
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_TransStopDate.ActiveEditAppearance = appearance116;
            this.tDateEdit_TransStopDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_TransStopDate.CalendarDisp = true;
            appearance117.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance117.TextHAlignAsString = "Left";
            appearance117.TextVAlignAsString = "Middle";
            this.tDateEdit_TransStopDate.EditAppearance = appearance117;
            this.tDateEdit_TransStopDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_TransStopDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tDateEdit_TransStopDate.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance118.TextHAlignAsString = "Left";
            appearance118.TextVAlignAsString = "Middle";
            this.tDateEdit_TransStopDate.LabelAppearance = appearance118;
            this.tDateEdit_TransStopDate.Location = new System.Drawing.Point(123, 277);
            this.tDateEdit_TransStopDate.Name = "tDateEdit_TransStopDate";
            this.tDateEdit_TransStopDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_TransStopDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_TransStopDate.Size = new System.Drawing.Size(156, 22);
            this.tDateEdit_TransStopDate.TabIndex = 1256;
            this.tDateEdit_TransStopDate.TabStop = true;
            // 
            // ultraLabel44
            // 
            appearance119.TextHAlignAsString = "Center";
            appearance119.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance119;
            this.ultraLabel44.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel44.Location = new System.Drawing.Point(811, 353);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel44.TabIndex = 1255;
            this.ultraLabel44.Text = "í[êîèàóù";
            // 
            // ultraLabel47
            // 
            appearance120.TextHAlignAsString = "Center";
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel47.Appearance = appearance120;
            this.ultraLabel47.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel47.Location = new System.Drawing.Point(811, 337);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ultraLabel47.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel47.TabIndex = 1254;
            this.ultraLabel47.Text = "íPâø";
            // 
            // ultraLabel45
            // 
            appearance121.TextHAlignAsString = "Center";
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel45.Appearance = appearance121;
            this.ultraLabel45.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel45.Location = new System.Drawing.Point(811, 389);
            this.ultraLabel45.Name = "ultraLabel45";
            this.ultraLabel45.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel45.TabIndex = 1253;
            this.ultraLabel45.Text = "í[êîèàóù";
            // 
            // ultraLabel46
            // 
            appearance122.TextHAlignAsString = "Center";
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance122;
            this.ultraLabel46.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel46.Location = new System.Drawing.Point(811, 372);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel46.TabIndex = 1252;
            this.ultraLabel46.Text = "ã‡äz";
            // 
            // ultraLabel41
            // 
            appearance127.TextHAlignAsString = "Center";
            appearance127.TextVAlignAsString = "Middle";
            this.ultraLabel41.Appearance = appearance127;
            this.ultraLabel41.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel41.Location = new System.Drawing.Point(30, 249);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel41.TabIndex = 1242;
            this.ultraLabel41.Text = "íSìñïœçXì˙";
            // 
            // tDateEdit_CustAgentChgDate
            // 
            appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_CustAgentChgDate.ActiveEditAppearance = appearance128;
            this.tDateEdit_CustAgentChgDate.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_CustAgentChgDate.CalendarDisp = true;
            appearance129.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance129.TextHAlignAsString = "Left";
            appearance129.TextVAlignAsString = "Middle";
            this.tDateEdit_CustAgentChgDate.EditAppearance = appearance129;
            this.tDateEdit_CustAgentChgDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_CustAgentChgDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tDateEdit_CustAgentChgDate.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance130.TextHAlignAsString = "Left";
            appearance130.TextVAlignAsString = "Middle";
            this.tDateEdit_CustAgentChgDate.LabelAppearance = appearance130;
            this.tDateEdit_CustAgentChgDate.Location = new System.Drawing.Point(123, 249);
            this.tDateEdit_CustAgentChgDate.Name = "tDateEdit_CustAgentChgDate";
            this.tDateEdit_CustAgentChgDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_CustAgentChgDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_CustAgentChgDate.Size = new System.Drawing.Size(156, 22);
            this.tDateEdit_CustAgentChgDate.TabIndex = 1241;
            this.tDateEdit_CustAgentChgDate.TabStop = true;
            this.tDateEdit_CustAgentChgDate.Enter += new System.EventHandler(this.tDateEdit_CustAgentChgDate_Enter);
            // 
            // ultraLabel36
            // 
            appearance135.TextHAlignAsString = "Center";
            appearance135.TextVAlignAsString = "Middle";
            this.ultraLabel36.Appearance = appearance135;
            this.ultraLabel36.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel36.Location = new System.Drawing.Point(591, 413);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel36.TabIndex = 1236;
            this.ultraLabel36.Text = "îÑä|ãÊï™";
            // 
            // ultraLabel33
            // 
            appearance136.TextHAlignAsString = "Center";
            appearance136.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance136;
            this.ultraLabel33.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel33.Location = new System.Drawing.Point(591, 378);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel33.TabIndex = 1235;
            this.ultraLabel33.Text = "ì¸ã‡è¡çû";
            // 
            // ultraLabel32
            // 
            appearance137.TextHAlignAsString = "Center";
            appearance137.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance137;
            this.ultraLabel32.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel32.Location = new System.Drawing.Point(591, 344);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel32.TabIndex = 1234;
            this.ultraLabel32.Text = "ó^êMä«óù";
            // 
            // tComboEditor_AccRecDivCd
            // 
            appearance144.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AccRecDivCd.ActiveAppearance = appearance144;
            appearance272.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance272.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_AccRecDivCd.Appearance = appearance272;
            this.tComboEditor_AccRecDivCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_AccRecDivCd.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance145.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_AccRecDivCd.ItemAppearance = appearance145;
            this.tComboEditor_AccRecDivCd.Location = new System.Drawing.Point(680, 413);
            this.tComboEditor_AccRecDivCd.Name = "tComboEditor_AccRecDivCd";
            this.tComboEditor_AccRecDivCd.Size = new System.Drawing.Size(125, 22);
            this.tComboEditor_AccRecDivCd.TabIndex = 1230;
            this.tComboEditor_AccRecDivCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_AccRecDivCd_SelectionChangeCommitted);
            // 
            // tComboEditor_DepoDelCode
            // 
            appearance146.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DepoDelCode.ActiveAppearance = appearance146;
            appearance271.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance271.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_DepoDelCode.Appearance = appearance271;
            this.tComboEditor_DepoDelCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_DepoDelCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance147.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_DepoDelCode.ItemAppearance = appearance147;
            this.tComboEditor_DepoDelCode.Location = new System.Drawing.Point(680, 378);
            this.tComboEditor_DepoDelCode.Name = "tComboEditor_DepoDelCode";
            this.tComboEditor_DepoDelCode.Size = new System.Drawing.Size(125, 22);
            this.tComboEditor_DepoDelCode.TabIndex = 1229;
            this.tComboEditor_DepoDelCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_DepoDelCode_SelectionChangeCommitted);
            // 
            // tComboEditor_CreditMngCode
            // 
            appearance148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CreditMngCode.ActiveAppearance = appearance148;
            appearance217.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance217.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CreditMngCode.Appearance = appearance217;
            this.tComboEditor_CreditMngCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CreditMngCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CreditMngCode.ItemAppearance = appearance149;
            this.tComboEditor_CreditMngCode.Location = new System.Drawing.Point(680, 343);
            this.tComboEditor_CreditMngCode.Name = "tComboEditor_CreditMngCode";
            this.tComboEditor_CreditMngCode.Size = new System.Drawing.Size(125, 22);
            this.tComboEditor_CreditMngCode.TabIndex = 1228;
            this.tComboEditor_CreditMngCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CreditMngCode_SelectionChangeCommitted);
            // 
            // uButton_OldCustomerAgentNmGuide
            // 
            this.uButton_OldCustomerAgentNmGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OldCustomerAgentNmGuide.Location = new System.Drawing.Point(527, 219);
            this.uButton_OldCustomerAgentNmGuide.Margin = new System.Windows.Forms.Padding(0);
            this.uButton_OldCustomerAgentNmGuide.Name = "uButton_OldCustomerAgentNmGuide";
            this.uButton_OldCustomerAgentNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_OldCustomerAgentNmGuide.TabIndex = 1226;
            this.toolTip1.SetToolTip(this.uButton_OldCustomerAgentNmGuide, "íSìñé“ÉKÉCÉh");
            this.uButton_OldCustomerAgentNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OldCustomerAgentNmGuide.Click += new System.EventHandler(this.uButton_OldCustomerAgentNmGuide_Click);
            // 
            // ultraLabel31
            // 
            appearance270.TextHAlignAsString = "Center";
            appearance270.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance270;
            this.ultraLabel31.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel31.Location = new System.Drawing.Point(326, 220);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(50, 22);
            this.ultraLabel31.TabIndex = 1227;
            this.ultraLabel31.Text = "ãåíSìñ";
            // 
            // tNedit_CollectSight
            // 
            appearance151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CollectSight.ActiveAppearance = appearance151;
            appearance152.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance152.TextHAlignAsString = "Right";
            this.tNedit_CollectSight.Appearance = appearance152;
            this.tNedit_CollectSight.AutoSelect = true;
            this.tNedit_CollectSight.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CollectSight.DataText = "";
            this.tNedit_CollectSight.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CollectSight.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CollectSight.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CollectSight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CollectSight.Location = new System.Drawing.Point(965, 182);
            this.tNedit_CollectSight.MaxLength = 3;
            this.tNedit_CollectSight.Name = "tNedit_CollectSight";
            this.tNedit_CollectSight.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CollectSight.Size = new System.Drawing.Size(32, 22);
            this.tNedit_CollectSight.TabIndex = 1224;
            // 
            // ultraLabel29
            // 
            appearance153.TextHAlignAsString = "Center";
            appearance153.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance153;
            this.ultraLabel29.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel29.Location = new System.Drawing.Point(590, 180);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel29.TabIndex = 1222;
            this.ultraLabel29.Text = "âÒé˚èåè";
            // 
            // tComboEditor_CollectCond
            // 
            appearance154.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CollectCond.ActiveAppearance = appearance154;
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance125.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CollectCond.Appearance = appearance125;
            this.tComboEditor_CollectCond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CollectCond.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_CollectCond.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CollectCond.ItemAppearance = appearance155;
            this.tComboEditor_CollectCond.Location = new System.Drawing.Point(680, 182);
            this.tComboEditor_CollectCond.Name = "tComboEditor_CollectCond";
            this.tComboEditor_CollectCond.Size = new System.Drawing.Size(216, 22);
            this.tComboEditor_CollectCond.TabIndex = 1221;
            this.tComboEditor_CollectCond.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CollectCond_SelectionChangeCommitted);
            // 
            // ultraLabel27
            // 
            appearance165.TextHAlignAsString = "Center";
            appearance165.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance165;
            this.ultraLabel27.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(30, 102);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel27.TabIndex = 1218;
            this.ultraLabel27.Text = "ìæà”êÊó™èÃ";
            // 
            // tEdit_CustomerSnm
            // 
            appearance166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerSnm.ActiveAppearance = appearance166;
            appearance167.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerSnm.Appearance = appearance167;
            this.tEdit_CustomerSnm.AutoSelect = true;
            this.tEdit_CustomerSnm.DataText = "";
            this.tEdit_CustomerSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_CustomerSnm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CustomerSnm.Location = new System.Drawing.Point(123, 103);
            this.tEdit_CustomerSnm.MaxLength = 20;
            this.tEdit_CustomerSnm.Name = "tEdit_CustomerSnm";
            this.tEdit_CustomerSnm.Size = new System.Drawing.Size(293, 22);
            this.tEdit_CustomerSnm.TabIndex = 1217;
            this.tEdit_CustomerSnm.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // ultraLabel17
            // 
            appearance168.TextHAlignAsString = "Center";
            appearance168.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance168;
            this.ultraLabel17.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel17.Location = new System.Drawing.Point(811, 425);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel17.TabIndex = 1214;
            this.ultraLabel17.Text = "í[êîèàóù";
            // 
            // ultraLabel18
            // 
            appearance169.TextHAlignAsString = "Center";
            appearance169.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance169;
            this.ultraLabel18.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel18.Location = new System.Drawing.Point(811, 408);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel18.TabIndex = 1212;
            this.ultraLabel18.Text = "è¡îÔê≈";
            // 
            // ultraLabel13
            // 
            appearance172.TextHAlignAsString = "Center";
            appearance172.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance172;
            this.ultraLabel13.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel13.Location = new System.Drawing.Point(811, 314);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel13.TabIndex = 1209;
            this.ultraLabel13.Text = "ì]â≈ï˚éÆ";
            // 
            // tComboEditor_ConsTaxLayMethod
            // 
            appearance173.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ConsTaxLayMethod.ActiveAppearance = appearance173;
            appearance161.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance161.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_ConsTaxLayMethod.Appearance = appearance161;
            this.tComboEditor_ConsTaxLayMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_ConsTaxLayMethod.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_ConsTaxLayMethod.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance174.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_ConsTaxLayMethod.ItemAppearance = appearance174;
            this.tComboEditor_ConsTaxLayMethod.Location = new System.Drawing.Point(877, 303);
            this.tComboEditor_ConsTaxLayMethod.MaxDropDownItems = 18;
            this.tComboEditor_ConsTaxLayMethod.Name = "tComboEditor_ConsTaxLayMethod";
            this.tComboEditor_ConsTaxLayMethod.Size = new System.Drawing.Size(120, 22);
            this.tComboEditor_ConsTaxLayMethod.TabIndex = 1208;
            this.tComboEditor_ConsTaxLayMethod.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_ConsTaxLayMethod_SelectionChangeCommitted);
            // 
            // ultraLabel6
            // 
            appearance181.TextHAlignAsString = "Center";
            appearance181.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance181;
            this.ultraLabel6.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.ultraLabel6.Location = new System.Drawing.Point(811, 297);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(62, 20);
            this.ultraLabel6.TabIndex = 1203;
            this.ultraLabel6.Text = "è¡îÔê≈";
            // 
            // ultraLabel1
            // 
            appearance184.TextHAlignAsString = "Center";
            appearance184.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance184;
            this.ultraLabel1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(31, 417);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel1.TabIndex = 1201;
            this.ultraLabel1.Text = "ínÅ@ãÊ";
            // 
            // ultraLabel19
            // 
            appearance185.TextHAlignAsString = "Center";
            appearance185.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance185;
            this.ultraLabel19.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(538, 2);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(45, 22);
            this.ultraLabel19.TabIndex = 1200;
            this.ultraLabel19.Text = "çÏê¨ì˙";
            // 
            // tDateEdit_UpdateDateTime
            // 
            appearance186.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_UpdateDateTime.ActiveEditAppearance = appearance186;
            this.tDateEdit_UpdateDateTime.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_UpdateDateTime.CalendarDisp = false;
            this.tDateEdit_UpdateDateTime.Cursor = System.Windows.Forms.Cursors.Default;
            appearance187.Cursor = System.Windows.Forms.Cursors.Arrow;
            appearance187.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance187.TextHAlignAsString = "Left";
            appearance187.TextVAlignAsString = "Middle";
            this.tDateEdit_UpdateDateTime.EditAppearance = appearance187;
            this.tDateEdit_UpdateDateTime.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_UpdateDateTime.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tDateEdit_UpdateDateTime.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance188.TextHAlignAsString = "Left";
            appearance188.TextVAlignAsString = "Middle";
            this.tDateEdit_UpdateDateTime.LabelAppearance = appearance188;
            this.tDateEdit_UpdateDateTime.Location = new System.Drawing.Point(782, 2);
            this.tDateEdit_UpdateDateTime.Name = "tDateEdit_UpdateDateTime";
            this.tDateEdit_UpdateDateTime.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_UpdateDateTime.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_UpdateDateTime.ReadOnly = true;
            this.tDateEdit_UpdateDateTime.Size = new System.Drawing.Size(143, 22);
            this.tDateEdit_UpdateDateTime.TabIndex = 1199;
            this.tDateEdit_UpdateDateTime.TabStop = true;
            // 
            // tDateEdit_CreateDateTime
            // 
            appearance189.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tDateEdit_CreateDateTime.ActiveEditAppearance = appearance189;
            this.tDateEdit_CreateDateTime.BackColor = System.Drawing.Color.Transparent;
            this.tDateEdit_CreateDateTime.CalendarDisp = false;
            this.tDateEdit_CreateDateTime.Cursor = System.Windows.Forms.Cursors.Default;
            appearance190.Cursor = System.Windows.Forms.Cursors.Arrow;
            appearance190.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance190.TextHAlignAsString = "Left";
            appearance190.TextVAlignAsString = "Middle";
            this.tDateEdit_CreateDateTime.EditAppearance = appearance190;
            this.tDateEdit_CreateDateTime.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.tDateEdit_CreateDateTime.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tDateEdit_CreateDateTime.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance191.TextHAlignAsString = "Left";
            appearance191.TextVAlignAsString = "Middle";
            this.tDateEdit_CreateDateTime.LabelAppearance = appearance191;
            this.tDateEdit_CreateDateTime.Location = new System.Drawing.Point(584, 2);
            this.tDateEdit_CreateDateTime.Name = "tDateEdit_CreateDateTime";
            this.tDateEdit_CreateDateTime.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.tDateEdit_CreateDateTime.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.tDateEdit_CreateDateTime.ReadOnly = true;
            this.tDateEdit_CreateDateTime.Size = new System.Drawing.Size(143, 22);
            this.tDateEdit_CreateDateTime.TabIndex = 1198;
            this.tDateEdit_CreateDateTime.TabStop = true;
            // 
            // ultraLabel22
            // 
            appearance192.TextHAlignAsString = "Center";
            appearance192.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance192;
            this.ultraLabel22.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(736, 2);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(45, 22);
            this.ultraLabel22.TabIndex = 1196;
            this.ultraLabel22.Text = "çXêVì˙";
            // 
            // CustomerKindTitle_ULabel
            // 
            appearance193.TextHAlignAsString = "Center";
            appearance193.TextVAlignAsString = "Middle";
            this.CustomerKindTitle_ULabel.Appearance = appearance193;
            this.CustomerKindTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerKindTitle_ULabel.Location = new System.Drawing.Point(307, 304);
            this.CustomerKindTitle_ULabel.Name = "CustomerKindTitle_ULabel";
            this.CustomerKindTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.CustomerKindTitle_ULabel.TabIndex = 1191;
            this.CustomerKindTitle_ULabel.Text = "ìæà”êÊéÌï ";
            // 
            // uLabel_ClaimName2
            // 
            appearance197.BackColor = System.Drawing.Color.Gainsboro;
            appearance197.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance197.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance197.TextHAlignAsString = "Left";
            appearance197.TextVAlignAsString = "Middle";
            this.uLabel_ClaimName2.Appearance = appearance197;
            this.uLabel_ClaimName2.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_ClaimName2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_ClaimName2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_ClaimName2.Location = new System.Drawing.Point(680, 106);
            this.uLabel_ClaimName2.Name = "uLabel_ClaimName2";
            this.uLabel_ClaimName2.Size = new System.Drawing.Size(318, 22);
            this.uLabel_ClaimName2.TabIndex = 303;
            this.uLabel_ClaimName2.WrapText = false;
            // 
            // tNedit_CustomerCode
            // 
            appearance198.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance198;
            appearance199.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance199.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance199.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance199;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(123, 31);
            this.tNedit_CustomerCode.MaxLength = 9;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(73, 22);
            this.tNedit_CustomerCode.TabIndex = 10;
            this.tNedit_CustomerCode.ValueChanged += new System.EventHandler(this.tNedit_CustomerCode_ValueChanged);
            // 
            // uButton_StyleChange
            // 
            this.uButton_StyleChange.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StyleChange.Location = new System.Drawing.Point(400, 4);
            this.uButton_StyleChange.Name = "uButton_StyleChange";
            this.uButton_StyleChange.Size = new System.Drawing.Size(55, 21);
            this.uButton_StyleChange.TabIndex = 1131;
            this.uButton_StyleChange.TabStop = false;
            this.uButton_StyleChange.Text = "Style";
            this.uButton_StyleChange.Visible = false;
            // 
            // uLabel_InputModeTitle
            // 
            appearance200.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(142)))), ((int)(((byte)(232)))));
            appearance200.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(14)))), ((int)(((byte)(138)))));
            appearance200.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance200.FontData.SizeInPoints = 9F;
            appearance200.ForeColor = System.Drawing.Color.Yellow;
            appearance200.TextHAlignAsString = "Center";
            appearance200.TextVAlignAsString = "Middle";
            this.uLabel_InputModeTitle.Appearance = appearance200;
            this.uLabel_InputModeTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_InputModeTitle.Location = new System.Drawing.Point(930, 2);
            this.uLabel_InputModeTitle.Name = "uLabel_InputModeTitle";
            this.uLabel_InputModeTitle.Size = new System.Drawing.Size(59, 22);
            this.uLabel_InputModeTitle.TabIndex = 1130;
            this.uLabel_InputModeTitle.Text = "çXêV";
            // 
            // tComboEditor_CollectMoneyCode
            // 
            appearance209.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CollectMoneyCode.ActiveAppearance = appearance209;
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance124.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_CollectMoneyCode.Appearance = appearance124;
            this.tComboEditor_CollectMoneyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_CollectMoneyCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_CollectMoneyCode.ItemAppearance = appearance210;
            this.tComboEditor_CollectMoneyCode.Location = new System.Drawing.Point(782, 154);
            this.tComboEditor_CollectMoneyCode.Name = "tComboEditor_CollectMoneyCode";
            this.tComboEditor_CollectMoneyCode.Size = new System.Drawing.Size(114, 22);
            this.tComboEditor_CollectMoneyCode.TabIndex = 306;
            this.tComboEditor_CollectMoneyCode.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_CollectMoneyCode_SelectionChangeCommitted);
            // 
            // tComboEditor_OutputNameCode
            // 
            appearance211.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputNameCode.ActiveAppearance = appearance211;
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance72.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_OutputNameCode.Appearance = appearance72;
            this.tComboEditor_OutputNameCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_OutputNameCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance212.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputNameCode.ItemAppearance = appearance212;
            this.tComboEditor_OutputNameCode.Location = new System.Drawing.Point(304, 151);
            this.tComboEditor_OutputNameCode.Name = "tComboEditor_OutputNameCode";
            this.tComboEditor_OutputNameCode.Size = new System.Drawing.Size(224, 22);
            this.tComboEditor_OutputNameCode.TabIndex = 16;
            // 
            // uLabel_CustomerClaimTitle
            // 
            appearance215.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance215.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance215.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance215.ForeColor = System.Drawing.Color.White;
            appearance215.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance215.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance215.TextHAlignAsString = "Center";
            appearance215.TextVAlignAsString = "Middle";
            this.uLabel_CustomerClaimTitle.Appearance = appearance215;
            this.uLabel_CustomerClaimTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_CustomerClaimTitle.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerClaimTitle.Location = new System.Drawing.Point(560, 26);
            this.uLabel_CustomerClaimTitle.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_CustomerClaimTitle.Name = "uLabel_CustomerClaimTitle";
            this.uLabel_CustomerClaimTitle.Size = new System.Drawing.Size(25, 423);
            this.uLabel_CustomerClaimTitle.TabIndex = 1113;
            this.uLabel_CustomerClaimTitle.Text = "êøãÅèÓïÒ";
            // 
            // uButton_ClaimNameGuide
            // 
            this.uButton_ClaimNameGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_ClaimNameGuide.Location = new System.Drawing.Point(755, 56);
            this.uButton_ClaimNameGuide.Name = "uButton_ClaimNameGuide";
            this.uButton_ClaimNameGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_ClaimNameGuide.TabIndex = 302;
            this.toolTip1.SetToolTip(this.uButton_ClaimNameGuide, "êøãÅêÊÉKÉCÉh");
            this.uButton_ClaimNameGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_ClaimNameGuide.Click += new System.EventHandler(this.uButton_ClaimNameGuide_Click);
            // 
            // ultraLabel59
            // 
            appearance218.TextHAlignAsString = "Center";
            appearance218.TextVAlignAsString = "Middle";
            this.ultraLabel59.Appearance = appearance218;
            this.ultraLabel59.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel59.Location = new System.Drawing.Point(586, 82);
            this.ultraLabel59.Name = "ultraLabel59";
            this.ultraLabel59.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel59.TabIndex = 1112;
            this.ultraLabel59.Text = "êøãÅêÊñº";
            // 
            // uLabel_CustomerNameTitle
            // 
            appearance219.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance219.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance219.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance219.ForeColor = System.Drawing.Color.White;
            appearance219.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance219.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance219.TextHAlignAsString = "Center";
            appearance219.TextVAlignAsString = "Middle";
            this.uLabel_CustomerNameTitle.Appearance = appearance219;
            this.uLabel_CustomerNameTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_CustomerNameTitle.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerNameTitle.Location = new System.Drawing.Point(4, 26);
            this.uLabel_CustomerNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_CustomerNameTitle.Name = "uLabel_CustomerNameTitle";
            this.uLabel_CustomerNameTitle.Size = new System.Drawing.Size(25, 154);
            this.uLabel_CustomerNameTitle.TabIndex = 1104;
            this.uLabel_CustomerNameTitle.Text = "ñºëO";
            // 
            // SubInfo_UTabControl
            // 
            appearance220.BackColor = System.Drawing.Color.White;
            appearance220.BackColor2 = System.Drawing.Color.Pink;
            this.SubInfo_UTabControl.ActiveTabAppearance = appearance220;
            appearance221.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            appearance221.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.SubInfo_UTabControl.ClientAreaAppearance = appearance221;
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo_UTabSharedControlsPage);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo2_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo4_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo5_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo0_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo6_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo7_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo8_UTabPageControl);
            this.SubInfo_UTabControl.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubInfo_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
            this.SubInfo_UTabControl.Location = new System.Drawing.Point(5, 455);
            this.SubInfo_UTabControl.Name = "SubInfo_UTabControl";
            this.SubInfo_UTabControl.SharedControlsPage = this.SubInfo_UTabSharedControlsPage;
            this.SubInfo_UTabControl.Size = new System.Drawing.Size(1000, 171);
            this.SubInfo_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubInfo_UTabControl.TabIndex = 1102;
            this.SubInfo_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft;
            ultraTab1.Key = "SubInfo0";
            ultraTab1.TabPage = this.SubInfo0_UTabPageControl;
            ultraTab1.Text = "(&1)òAóçêÊèÓïÒ";
            ultraTab2.Key = "SubInfo2";
            ultraTab2.TabPage = this.SubInfo2_UTabPageControl;
            ultraTab2.Text = "(&2)îıçlèÓïÒ";
            ultraTab3.Key = "SubInfo4";
            ultraTab3.TabPage = this.SubInfo4_UTabPageControl;
            ultraTab3.Text = "(&3)ÇdÉÅÅ[ÉãèÓïÒ";
            ultraTab4.Key = "SubInfo5";
            ultraTab4.TabPage = this.SubInfo5_UTabPageControl;
            ultraTab4.Text = "(&4)å˚ç¿èÓïÒ";
            ultraTab6.Key = "SubInfo6";
            ultraTab6.TabPage = this.SubInfo6_UTabPageControl;
            ultraTab6.Text = "(&5)ì`ï[ÅEêøãÅèëèÓïÒ";
            ultraTab5.Key = "SubInfo7";
            ultraTab5.TabPage = this.SubInfo7_UTabPageControl;
            ultraTab5.Text = "(&6)ÉIÉìÉâÉCÉìèÓïÒ";
            ultraTab7.Key = "SubInfo8";
            ultraTab7.TabPage = this.SubInfo8_UTabPageControl;
            ultraTab7.Text = "(&7)ÉÅÉÇèÓïÒ";
            this.SubInfo_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2,
            ultraTab3,
            ultraTab4,
            ultraTab6,
            ultraTab5,
            ultraTab7});
            this.SubInfo_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // SubInfo_UTabSharedControlsPage
            // 
            this.SubInfo_UTabSharedControlsPage.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo_UTabSharedControlsPage.Name = "SubInfo_UTabSharedControlsPage";
            this.SubInfo_UTabSharedControlsPage.Size = new System.Drawing.Size(998, 149);
            // 
            // uButton_BillCollecterNmGuide
            // 
            this.uButton_BillCollecterNmGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_BillCollecterNmGuide.Location = new System.Drawing.Point(974, 233);
            this.uButton_BillCollecterNmGuide.Name = "uButton_BillCollecterNmGuide";
            this.uButton_BillCollecterNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_BillCollecterNmGuide.TabIndex = 310;
            this.toolTip1.SetToolTip(this.uButton_BillCollecterNmGuide, "íSìñé“ÉKÉCÉh");
            this.uButton_BillCollecterNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_BillCollecterNmGuide.Click += new System.EventHandler(this.uButton_BillCollecterNmGuide_Click);
            // 
            // uButton_CustomerAgentNmGuide
            // 
            this.uButton_CustomerAgentNmGuide.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerAgentNmGuide.Location = new System.Drawing.Point(255, 219);
            this.uButton_CustomerAgentNmGuide.Margin = new System.Windows.Forms.Padding(0);
            this.uButton_CustomerAgentNmGuide.Name = "uButton_CustomerAgentNmGuide";
            this.uButton_CustomerAgentNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerAgentNmGuide.TabIndex = 308;
            this.toolTip1.SetToolTip(this.uButton_CustomerAgentNmGuide, "íSìñé“ÉKÉCÉh");
            this.uButton_CustomerAgentNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerAgentNmGuide.Click += new System.EventHandler(this.uButton_CustomerAgentNmGuide_Click);
            // 
            // tEdit_BillCollecterNm
            // 
            appearance222.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_BillCollecterNm.ActiveAppearance = appearance222;
            appearance290.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_BillCollecterNm.Appearance = appearance290;
            this.tEdit_BillCollecterNm.AutoSelect = true;
            this.tEdit_BillCollecterNm.DataText = "";
            this.tEdit_BillCollecterNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_BillCollecterNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_BillCollecterNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_BillCollecterNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_BillCollecterNm.Location = new System.Drawing.Point(680, 234);
            this.tEdit_BillCollecterNm.MaxLength = 30;
            this.tEdit_BillCollecterNm.Name = "tEdit_BillCollecterNm";
            this.tEdit_BillCollecterNm.Size = new System.Drawing.Size(293, 22);
            this.tEdit_BillCollecterNm.TabIndex = 309;
            // 
            // tEdit_CustomerAgentNm
            // 
            appearance317.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerAgentNm.ActiveAppearance = appearance317;
            appearance318.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerAgentNm.Appearance = appearance318;
            this.tEdit_CustomerAgentNm.AutoSelect = true;
            this.tEdit_CustomerAgentNm.DataText = "";
            this.tEdit_CustomerAgentNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerAgentNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustomerAgentNm.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerAgentNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_CustomerAgentNm.Location = new System.Drawing.Point(123, 220);
            this.tEdit_CustomerAgentNm.Margin = new System.Windows.Forms.Padding(0);
            this.tEdit_CustomerAgentNm.MaxLength = 30;
            this.tEdit_CustomerAgentNm.Name = "tEdit_CustomerAgentNm";
            this.tEdit_CustomerAgentNm.Size = new System.Drawing.Size(128, 22);
            this.tEdit_CustomerAgentNm.TabIndex = 307;
            // 
            // BillCollecterNmTitle_ULabel
            // 
            appearance225.TextHAlignAsString = "Center";
            appearance225.TextVAlignAsString = "Middle";
            this.BillCollecterNmTitle_ULabel.Appearance = appearance225;
            this.BillCollecterNmTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillCollecterNmTitle_ULabel.Location = new System.Drawing.Point(590, 234);
            this.BillCollecterNmTitle_ULabel.Name = "BillCollecterNmTitle_ULabel";
            this.BillCollecterNmTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.BillCollecterNmTitle_ULabel.TabIndex = 522;
            this.BillCollecterNmTitle_ULabel.Text = "èWã‡íSìñ";
            // 
            // CustomerAgentNmTitle_ULabel
            // 
            appearance226.TextHAlignAsString = "Center";
            appearance226.TextVAlignAsString = "Middle";
            this.CustomerAgentNmTitle_ULabel.Appearance = appearance226;
            this.CustomerAgentNmTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerAgentNmTitle_ULabel.Location = new System.Drawing.Point(30, 221);
            this.CustomerAgentNmTitle_ULabel.Name = "CustomerAgentNmTitle_ULabel";
            this.CustomerAgentNmTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.CustomerAgentNmTitle_ULabel.TabIndex = 520;
            this.CustomerAgentNmTitle_ULabel.Text = "ìæà”êÊíSìñ";
            // 
            // tNedit_CollectMoneyDay
            // 
            appearance227.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CollectMoneyDay.ActiveAppearance = appearance227;
            appearance228.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance228.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance228.TextHAlignAsString = "Right";
            this.tNedit_CollectMoneyDay.Appearance = appearance228;
            this.tNedit_CollectMoneyDay.AutoSelect = true;
            this.tNedit_CollectMoneyDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CollectMoneyDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CollectMoneyDay.DataText = "";
            this.tNedit_CollectMoneyDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CollectMoneyDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_CollectMoneyDay.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CollectMoneyDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CollectMoneyDay.Location = new System.Drawing.Point(972, 154);
            this.tNedit_CollectMoneyDay.MaxLength = 2;
            this.tNedit_CollectMoneyDay.Name = "tNedit_CollectMoneyDay";
            this.tNedit_CollectMoneyDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CollectMoneyDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_CollectMoneyDay.TabIndex = 305;
            // 
            // CollectMoneyCodeTitle_ULabel
            // 
            appearance229.TextHAlignAsString = "Center";
            appearance229.TextVAlignAsString = "Middle";
            this.CollectMoneyCodeTitle_ULabel.Appearance = appearance229;
            this.CollectMoneyCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectMoneyCodeTitle_ULabel.Location = new System.Drawing.Point(707, 154);
            this.CollectMoneyCodeTitle_ULabel.Name = "CollectMoneyCodeTitle_ULabel";
            this.CollectMoneyCodeTitle_ULabel.Size = new System.Drawing.Size(82, 22);
            this.CollectMoneyCodeTitle_ULabel.TabIndex = 510;
            this.CollectMoneyCodeTitle_ULabel.Text = "èWã‡åé";
            // 
            // CollectMoneyDayTitle_ULabel
            // 
            appearance230.TextHAlignAsString = "Center";
            appearance230.TextVAlignAsString = "Middle";
            this.CollectMoneyDayTitle_ULabel.Appearance = appearance230;
            this.CollectMoneyDayTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F);
            this.CollectMoneyDayTitle_ULabel.Location = new System.Drawing.Point(910, 154);
            this.CollectMoneyDayTitle_ULabel.Name = "CollectMoneyDayTitle_ULabel";
            this.CollectMoneyDayTitle_ULabel.Size = new System.Drawing.Size(50, 22);
            this.CollectMoneyDayTitle_ULabel.TabIndex = 509;
            this.CollectMoneyDayTitle_ULabel.Text = "èWã‡ì˙";
            // 
            // tNedit_TotalDay
            // 
            appearance231.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_TotalDay.ActiveAppearance = appearance231;
            appearance232.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance232.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance232.TextHAlignAsString = "Right";
            this.tNedit_TotalDay.Appearance = appearance232;
            this.tNedit_TotalDay.AutoSelect = true;
            this.tNedit_TotalDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_TotalDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_TotalDay.DataText = "";
            this.tNedit_TotalDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_TotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_TotalDay.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_TotalDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_TotalDay.Location = new System.Drawing.Point(680, 154);
            this.tNedit_TotalDay.MaxLength = 2;
            this.tNedit_TotalDay.Name = "tNedit_TotalDay";
            this.tNedit_TotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_TotalDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_TotalDay.TabIndex = 304;
            // 
            // TotalDayTitle_ULabel
            // 
            appearance233.TextHAlignAsString = "Center";
            appearance233.TextVAlignAsString = "Middle";
            this.TotalDayTitle_ULabel.Appearance = appearance233;
            this.TotalDayTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDayTitle_ULabel.Location = new System.Drawing.Point(590, 154);
            this.TotalDayTitle_ULabel.Name = "TotalDayTitle_ULabel";
            this.TotalDayTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.TotalDayTitle_ULabel.TabIndex = 508;
            this.TotalDayTitle_ULabel.Text = "í˜Å@ì˙";
            // 
            // ultraLabel35
            // 
            appearance236.TextHAlignAsString = "Center";
            appearance236.TextVAlignAsString = "Middle";
            this.ultraLabel35.Appearance = appearance236;
            this.ultraLabel35.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel35.Location = new System.Drawing.Point(214, 151);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(90, 22);
            this.ultraLabel35.TabIndex = 502;
            this.ultraLabel35.Text = "èîÅ@å˚";
            // 
            // ultraLabel34
            // 
            appearance237.TextHAlignAsString = "Center";
            appearance237.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance237;
            this.ultraLabel34.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel34.Location = new System.Drawing.Point(32, 151);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel34.TabIndex = 501;
            this.ultraLabel34.Text = "åhÅ@èÃ";
            // 
            // ultraLabel56
            // 
            appearance238.TextHAlignAsString = "Center";
            appearance238.TextVAlignAsString = "Middle";
            this.ultraLabel56.Appearance = appearance238;
            this.ultraLabel56.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel56.Location = new System.Drawing.Point(214, 31);
            this.ultraLabel56.Name = "ultraLabel56";
            this.ultraLabel56.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel56.TabIndex = 314;
            this.ultraLabel56.Text = "ÉTÉuÉRÅ[Éh";
            // 
            // ultraLabel10
            // 
            appearance239.TextHAlignAsString = "Center";
            appearance239.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance239;
            this.ultraLabel10.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(32, 31);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel10.TabIndex = 312;
            this.ultraLabel10.Text = "ìæà”êÊÉRÅ[Éh";
            // 
            // ultraLabel11
            // 
            appearance240.TextHAlignAsString = "Center";
            appearance240.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance240;
            this.ultraLabel11.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(32, 56);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel11.TabIndex = 313;
            this.ultraLabel11.Text = "ìæà”êÊñº";
            // 
            // ultraLabel12
            // 
            appearance241.TextHAlignAsString = "Center";
            appearance241.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance241;
            this.ultraLabel12.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(30, 126);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel12.TabIndex = 311;
            this.ultraLabel12.Text = "ìæà”êÊñº(∂≈)";
            // 
            // tEdit_Kana
            // 
            appearance242.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Kana.ActiveAppearance = appearance242;
            appearance243.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance243.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Kana.Appearance = appearance243;
            this.tEdit_Kana.AutoSelect = true;
            this.tEdit_Kana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_Kana.DataText = "";
            this.tEdit_Kana.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Kana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_Kana.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Kana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_Kana.Location = new System.Drawing.Point(123, 127);
            this.tEdit_Kana.MaxLength = 30;
            this.tEdit_Kana.Name = "tEdit_Kana";
            this.tEdit_Kana.Size = new System.Drawing.Size(217, 22);
            this.tEdit_Kana.TabIndex = 14;
            this.tEdit_Kana.ValueChanged += new System.EventHandler(this.tEdit_Kana_ValueChanged);
            // 
            // tEdit_Name2
            // 
            appearance283.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Name2.ActiveAppearance = appearance283;
            appearance214.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Name2.Appearance = appearance214;
            this.tEdit_Name2.AutoSelect = true;
            this.tEdit_Name2.DataText = "";
            this.tEdit_Name2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Name2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_Name2.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Name2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Name2.Location = new System.Drawing.Point(123, 79);
            this.tEdit_Name2.MaxLength = 30;
            this.tEdit_Name2.Name = "tEdit_Name2";
            this.tEdit_Name2.Size = new System.Drawing.Size(430, 22);
            this.tEdit_Name2.TabIndex = 13;
            this.tEdit_Name2.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // tEdit_Name
            // 
            appearance245.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_Name.ActiveAppearance = appearance245;
            appearance246.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_Name.Appearance = appearance246;
            this.tEdit_Name.AutoSelect = true;
            this.tEdit_Name.DataText = "";
            this.tEdit_Name.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_Name.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_Name.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_Name.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_Name.Location = new System.Drawing.Point(123, 55);
            this.tEdit_Name.MaxLength = 30;
            this.tEdit_Name.Name = "tEdit_Name";
            this.tEdit_Name.Size = new System.Drawing.Size(430, 22);
            this.tEdit_Name.TabIndex = 12;
            this.tEdit_Name.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // tEdit_CustomerSubCode
            // 
            appearance247.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustomerSubCode.ActiveAppearance = appearance247;
            appearance213.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_CustomerSubCode.Appearance = appearance213;
            this.tEdit_CustomerSubCode.AutoSelect = true;
            this.tEdit_CustomerSubCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_CustomerSubCode.DataText = "";
            this.tEdit_CustomerSubCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustomerSubCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_CustomerSubCode.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustomerSubCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_CustomerSubCode.Location = new System.Drawing.Point(304, 31);
            this.tEdit_CustomerSubCode.MaxLength = 20;
            this.tEdit_CustomerSubCode.Name = "tEdit_CustomerSubCode";
            this.tEdit_CustomerSubCode.Size = new System.Drawing.Size(149, 22);
            this.tEdit_CustomerSubCode.TabIndex = 11;
            // 
            // uLabel_CustomerDetailsTitle
            // 
            appearance254.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance254.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance254.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance254.ForeColor = System.Drawing.Color.White;
            appearance254.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance254.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance254.TextHAlignAsString = "Center";
            appearance254.TextVAlignAsString = "Middle";
            this.uLabel_CustomerDetailsTitle.Appearance = appearance254;
            this.uLabel_CustomerDetailsTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_CustomerDetailsTitle.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerDetailsTitle.Location = new System.Drawing.Point(4, 186);
            this.uLabel_CustomerDetailsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_CustomerDetailsTitle.Name = "uLabel_CustomerDetailsTitle";
            this.uLabel_CustomerDetailsTitle.Size = new System.Drawing.Size(25, 263);
            this.uLabel_CustomerDetailsTitle.TabIndex = 1114;
            this.uLabel_CustomerDetailsTitle.Text = "è⁄ç◊èÓïÒ";
            // 
            // BusinessTypeCodeTitle_ULabel
            // 
            appearance261.TextHAlignAsString = "Center";
            appearance261.TextVAlignAsString = "Middle";
            this.BusinessTypeCodeTitle_ULabel.Appearance = appearance261;
            this.BusinessTypeCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BusinessTypeCodeTitle_ULabel.Location = new System.Drawing.Point(30, 361);
            this.BusinessTypeCodeTitle_ULabel.Name = "BusinessTypeCodeTitle_ULabel";
            this.BusinessTypeCodeTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.BusinessTypeCodeTitle_ULabel.TabIndex = 359;
            this.BusinessTypeCodeTitle_ULabel.Text = "ã∆Å@éÌ";
            // 
            // JobTypeCodeTitle_ULabel
            // 
            appearance262.TextHAlignAsString = "Center";
            appearance262.TextVAlignAsString = "Middle";
            this.JobTypeCodeTitle_ULabel.Appearance = appearance262;
            this.JobTypeCodeTitle_ULabel.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.JobTypeCodeTitle_ULabel.Location = new System.Drawing.Point(30, 390);
            this.JobTypeCodeTitle_ULabel.Name = "JobTypeCodeTitle_ULabel";
            this.JobTypeCodeTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.JobTypeCodeTitle_ULabel.TabIndex = 358;
            this.JobTypeCodeTitle_ULabel.Text = "êEÅ@éÌ";
            // 
            // ultraLabel61
            // 
            this.ultraLabel61.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel61.Location = new System.Drawing.Point(29, 26);
            this.ultraLabel61.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel61.Name = "ultraLabel61";
            this.ultraLabel61.Size = new System.Drawing.Size(531, 154);
            this.ultraLabel61.TabIndex = 1127;
            // 
            // ultraLabel62
            // 
            this.ultraLabel62.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel62.Location = new System.Drawing.Point(585, 26);
            this.ultraLabel62.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel62.Name = "ultraLabel62";
            this.ultraLabel62.Size = new System.Drawing.Size(420, 423);
            this.ultraLabel62.TabIndex = 1128;
            // 
            // CustomerDetails_ULabel
            // 
            this.CustomerDetails_ULabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.CustomerDetails_ULabel.Location = new System.Drawing.Point(29, 186);
            this.CustomerDetails_ULabel.Name = "CustomerDetails_ULabel";
            this.CustomerDetails_ULabel.Size = new System.Drawing.Size(531, 263);
            this.CustomerDetails_ULabel.TabIndex = 1129;
            // 
            // ultraGridBagLayoutManager1
            // 
            this.ultraGridBagLayoutManager1.ContainerControl = this.BackGround_Panel;
            this.ultraGridBagLayoutManager1.ExpandToFitHeight = true;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Initialize_Timer
            // 
            this.Initialize_Timer.Interval = 1;
            this.Initialize_Timer.Tick += new System.EventHandler(this.Initialize_Timer_Tick);
            // 
            // NameToKana_TImeControl
            // 
            this.NameToKana_TImeControl.InControl = this.tEdit_Name;
            this.NameToKana_TImeControl.OutControl = this.tEdit_Kana;
            this.NameToKana_TImeControl.OwnerForm = this;
            // 
            // tAttack251
            // 
            this.tAttack251.OwnerForm = this;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.contextMenuStrip1.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Undo,
            this.toolStripSeparator1,
            this.toolStripMenuItem_Cut,
            this.toolStripMenuItem_Copy,
            this.toolStripMenuItem_Paste,
            this.toolStripMenuItem_Clear,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Select});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 148);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem_Undo
            // 
            this.toolStripMenuItem_Undo.Name = "toolStripMenuItem_Undo";
            this.toolStripMenuItem_Undo.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Undo.Text = "å≥Ç…ñﬂÇ∑(&U)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // toolStripMenuItem_Cut
            // 
            this.toolStripMenuItem_Cut.Name = "toolStripMenuItem_Cut";
            this.toolStripMenuItem_Cut.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Cut.Text = "êÿÇËéÊÇË(&T)";
            // 
            // toolStripMenuItem_Copy
            // 
            this.toolStripMenuItem_Copy.Name = "toolStripMenuItem_Copy";
            this.toolStripMenuItem_Copy.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Copy.Text = "ÉRÉsÅ[(&C)";
            // 
            // toolStripMenuItem_Paste
            // 
            this.toolStripMenuItem_Paste.Name = "toolStripMenuItem_Paste";
            this.toolStripMenuItem_Paste.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Paste.Text = "ì\ÇËïtÇØ(&P)";
            // 
            // toolStripMenuItem_Clear
            // 
            this.toolStripMenuItem_Clear.Name = "toolStripMenuItem_Clear";
            this.toolStripMenuItem_Clear.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Clear.Text = "çÌèú(&D)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(120, 6);
            // 
            // toolStripMenuItem_Select
            // 
            this.toolStripMenuItem_Select.Name = "toolStripMenuItem_Select";
            this.toolStripMenuItem_Select.Size = new System.Drawing.Size(123, 22);
            this.toolStripMenuItem_Select.Text = "Ç∑Ç◊ÇƒëIë(&A)";
            // 
            // PMKHN09010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1013, 633);
            this.Controls.Add(this.BackGround_Panel);
            this.Font = new System.Drawing.Font("ÇlÇr ÉSÉVÉbÉN", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PMKHN09010UA";
            this.Text = "äÓñ{èÓïÒ";
            this.Load += new System.EventHandler(this.PMKHN09010UA_Load);
            this.SubInfo0_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo0.ResumeLayout(false);
            this.panel_SubInfo0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PostNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_Address2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Address4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HomeTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OfficeTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PortableTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OthersTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HomeFaxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OfficeFaxNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SearchTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MainContactCode)).EndInit();
            this.SubInfo2_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Note5)).EndInit();
            this.SubInfo4_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo4.ResumeLayout(false);
            this.panel_SubInfo4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailAddrKindCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailAddrKindCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailSendCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_MailSendCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MailAddress2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MailAddress1)).EndInit();
            this.SubInfo5_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_AccountNoInfo1)).EndInit();
            this.SubInfo6_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo6.ResumeLayout(false);
            this.panel_SubInfo6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SlipTtlBillOutputDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DetailBillOutputCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TotalBillOutputDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_UOESlipPrtDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_EstimatePrtDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ShipmSlipPrtDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AcpOdrrSlipPrtDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesSlipPrtDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_QrcodePrtCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ReceiptOutputCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DmOutCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustSlipNoMngCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerSlipNoDiv)).EndInit();
            this.SubInfo7_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo7.ResumeLayout(false);
            this.panel_SubInfo7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SimplInqAcntAcntGrId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OnlineKindDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerEpCode)).EndInit();
            this.SubInfo8_UTabPageControl.ResumeLayout(false);
            this.panel_SubInfo8.ResumeLayout(false);
            this.panel_SubInfo8.PerformLayout();
            this.BackGround_Panel.ResumeLayout(false);
            this.Container_Panel.ResumeLayout(false);
            this.Container_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_JobTypeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesAreaNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BusinessTypeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_HonorificTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustWarehouseCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CarMngDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_ClaimSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CorporateDivCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerAttributeDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustAnalysCode5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldCustomerAgentNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesCnsTaxFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesMoneyFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesUnPrcFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustCTaXLayRefCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CustomerDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_AccRecDivCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_DepoDelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CreditMngCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CollectSight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CollectCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_ConsTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_CollectMoneyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputNameCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).EndInit();
            this.SubInfo_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_BillCollecterNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerAgentNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CollectMoneyDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_TotalDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Kana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Name2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustomerSubCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridBagLayoutManager1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private Infragistics.Win.Misc.UltraLabel CustomerKindTitle_ULabel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel22;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 tDateEdit_UpdateDateTime;
        private Broadleaf.Library.Windows.Forms.TDateEdit2 tDateEdit_CreateDateTime;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_ConsTaxLayMethod;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo5Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo0Title;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubInfo_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage SubInfo_UTabSharedControlsPage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo1_UTabPageControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo2_UTabPageControl;
        private System.Windows.Forms.Panel panel_SubInfo2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note9;
        private Infragistics.Win.Misc.UltraButton uButton_Note4Guide;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note9Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note4;
        private Infragistics.Win.Misc.UltraButton uButton_Note8Guide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note8;
        private Infragistics.Win.Misc.UltraButton uButton_Note3Guide;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note8Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note3;
        private Infragistics.Win.Misc.UltraButton uButton_Note7Guide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note7;
        private Infragistics.Win.Misc.UltraButton uButton_Note2Guide;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note7Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note2;
        private Infragistics.Win.Misc.UltraButton uButton_Note6Guide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note6;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note2Title;
        private Infragistics.Win.Misc.UltraButton uButton_Note1Guide;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note6Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note1;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note1Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note5Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note4Title;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note3Title;
        private Infragistics.Win.Misc.UltraButton uButton_Note10Guide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note10;
        private Infragistics.Win.Misc.UltraButton uButton_Note5Guide;
        private Infragistics.Win.Misc.UltraLabel uLabel_Note10Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Note5;
        private Infragistics.Win.Misc.UltraButton uButton_Note9Guide;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo4_UTabPageControl;
        private System.Windows.Forms.Panel panel_SubInfo4;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_MailAddrKindCode2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_MailAddrKindCode1;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_MailSendCode2;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_MailSendCode1;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MailAddress2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MailAddress1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo5_UTabPageControl;
        private System.Windows.Forms.Panel panel_SubInfo5;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_AccountNoInfo3;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_AccountNoInfo2;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_AccountNoInfo1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo0_UTabPageControl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PostNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Address1;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_Address2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Address3;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_Address4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraButton uButton_AddressGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_HomeTelNo;
        private Infragistics.Win.Misc.UltraLabel uLabel_HomeTelNoDspName;
        private Infragistics.Win.Misc.UltraLabel uLabel_OfficeTelNoDspName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_OfficeTelNo;
        private Infragistics.Win.Misc.UltraLabel uLabel_MobileTelNoDspName;
        private Infragistics.Win.Misc.UltraLabel uLabel_OtherTelNoDspName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_PortableTelNo;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_OthersTelNo;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_HomeFaxNo;
        private Infragistics.Win.Misc.UltraLabel uLabel_HomeFaxNoDspName;
        private Infragistics.Win.Misc.UltraLabel uLabel_OfficeFaxNoDspName;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_OfficeFaxNo;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SearchTelNo;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_MainContactCode;
        private System.Windows.Forms.Panel panel_SubInfo0;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerSnm;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustomerAttributeDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CollectSight;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CollectCond;
        private Infragistics.Win.Misc.UltraButton uButton_OldCustomerAgentNmGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_OldCustomerAgentNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AccRecDivCd;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_DepoDelCode;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CreditMngCode;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustSlipNoMngCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel38;
        private Infragistics.Win.Misc.UltraLabel ultraLabel36;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private Infragistics.Win.Misc.UltraLabel ultraLabel41;
        private Broadleaf.Library.Windows.Forms.TDateEdit2 tDateEdit_CustAgentChgDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel45;
        private Infragistics.Win.Misc.UltraLabel ultraLabel46;
        private Infragistics.Win.Misc.UltraLabel ultraLabel48;
        private Broadleaf.Library.Windows.Forms.TDateEdit2 tDateEdit_TransStopDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel44;
        private Infragistics.Win.Misc.UltraLabel ultraLabel47;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private Infragistics.Win.Misc.UltraLabel ultraLabel51;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustomerDivCd;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustomerSlipNoDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraLabel ultraLabel53;
        private Infragistics.Win.Misc.UltraLabel uLabel_ClaimSnm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel54;
        private Infragistics.Win.Misc.UltraLabel ultraLabel52;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CustCTaXLayRefCd;
        private Infragistics.Win.Misc.UltraButton uButton_SalesUnPrcFrcProcCdGuide;
        private Infragistics.Win.Misc.UltraButton uButton_SalesCnsTaxFrcProcCdGuide;
        private Infragistics.Win.Misc.UltraButton uButton_SalesMoneyFrcProcCdGuide;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesCnsTaxFrcProcCd;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesMoneyFrcProcCd;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SalesUnPrcFrcProcCd;
        private Infragistics.Win.Misc.UltraButton uButton_MngSectionNmGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_MngSectionNm;
        private Infragistics.Win.Misc.UltraLabel ultraLabel57;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_ClaimCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel55;
        private Infragistics.Win.Misc.UltraLabel uLabel_ClaimName1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel60;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_NTimeCalcStDate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel58;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerAgent;
        private Infragistics.Win.Misc.UltraLabel ultraLabel64;
        private Broadleaf.Library.Windows.Forms.UiSetControl uiSetControl1;
        internal Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo6_UTabPageControl;
        private System.Windows.Forms.Panel panel_SubInfo6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel63;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_QrcodePrtCd;
        private Infragistics.Win.Misc.UltraButton uButton_ClaimSectionGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_ClaimSectionCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustWarehouseCd;
        private Infragistics.Win.Misc.UltraButton uButton_CustWarehouseGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLabel50;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_CarMngDivCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel49;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo6Title;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_HonorificTitle;
        private System.Windows.Forms.RadioButton rButton_MainSendMailAddrCd1;
        private System.Windows.Forms.RadioButton rButton_MainSendMailAddrCd0;
        private Infragistics.Win.Misc.UltraLabel UOESlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel EstimatePrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel ShipmSlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel AcpOdrrSlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel SalesSlipPrtDiv_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_UOESlipPrtDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_EstimatePrtDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_ShipmSlipPrtDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_AcpOdrrSlipPrtDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SalesSlipPrtDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_ReceiptOutputCode;
        private Infragistics.Win.Misc.UltraLabel ReceiptOutputCode_uLabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo7_UTabPageControl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_OnlineKindDiv;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerSecCode;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_CustomerEpCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private System.Windows.Forms.Panel panel_SubInfo7;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo7Title;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Infragistics.Win.Misc.UltraLabel ultraLabel39;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_TotalBillOutputDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_SlipTtlBillOutputDiv;
        private Broadleaf.Library.Windows.Forms.TComboEditor tComboEditor_DetailBillOutputCode;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SimplInqAcntAcntGrId;
        private Infragistics.Win.Misc.UltraLabel ultraLabel65;
        private Infragistics.Win.Misc.UltraButton uButton_BusinessTypeCdGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_BusinessTypeNm;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SalesAreaNm;
        private Infragistics.Win.Misc.UltraButton uButton_SalesAreaCdGuide;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_JobTypeName;
        private Infragistics.Win.Misc.UltraButton uButton_JobTypeCodeGuide;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo8_UTabPageControl;
        private System.Windows.Forms.Panel panel_SubInfo8;
        private Infragistics.Win.Misc.UltraLabel uLabel_SubInfo8Title;
        private System.Windows.Forms.RichTextBox memo_richTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Undo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Cut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Copy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Select;
        private System.Windows.Forms.CheckBox check_CustomerInfoGuideDisp;

	}
}
