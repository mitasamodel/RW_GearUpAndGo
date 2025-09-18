using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;

namespace GearUpAndGo
{
	public class Settings : ModSettings
	{
		public string betterPawnControlBattlePolicy = "";
		public bool CE_ChangeLoadoutFirst = true;

		public void DoWindowContents(Rect wrect)
		{
			var options = new Listing_Standard();
			options.Begin(wrect);

			options.Label("TD.SettingBetterPawnControlPolicy".Translate());
			betterPawnControlBattlePolicy = options.TextEntry(betterPawnControlBattlePolicy, 1);
			options.Label("TD.SettingBetterPawnControlCustom".Translate());
			options.Label("TD.SettingBetterPawnControlRemembered".Translate());
			options.Gap();
			if (ModsConfig.IsActive("CETeam.CombatExtended"))
			{
				options.CheckboxLabeled("Combat Extended: change loadout first", ref CE_ChangeLoadoutFirst);
			}
			options.Gap();

			options.End();
		}

		public override void ExposeData()
		{
			Scribe_Values.Look(ref betterPawnControlBattlePolicy, "betterPawnControlBattlePolicy", "");
			Scribe_Values.Look(ref CE_ChangeLoadoutFirst, "CE_ChangeLoadoutFirst", true);
		}
	}
}