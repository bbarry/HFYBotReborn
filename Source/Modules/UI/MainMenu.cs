using System;

namespace HFYBot.Modules.UI
{
	/// <summary>
	/// The main menu. exactly what it sounds like. Think of it like a gatekeeper.
	/// </summary>
	public class MainMenu:UIMenu
	{
		public MainMenu (HFYBot.Modules.UserInterfaceModule module):base(module)
		{
			displayText = "==========HFYBotReborn==========\n\n" + getModuleNamesAndStates() + "\n\n1) Toggle Modules\n2) Refresh Listings\n3) Exit";
			exitConf = new ExitConfMenu (module);
			lazy = new LazyMan (module);
		}

		public override void receiveKey (ConsoleKey key)
		{
			switch (key) {
			case(ConsoleKey.D1):
				module.MakeMenuTransition (lazy);
				break;
			case(ConsoleKey.D2):
				updateText();
				break;
			case(ConsoleKey.D3):
				module.MakeMenuTransition (exitConf);
				break;
			}
		}

		public override void updateText ()
		{
			displayText = "==========HFYBotReborn==========\n\n" + getModuleNamesAndStates() + "\n\n1) Toggle Modules\n2) Refresh Listings\n3) Exit";
			Console.Clear ();
			Console.Write (displayText);
		}

		public string getModuleNamesAndStates(){
			string[] moduleNames = Program.getModuleNames ();
			string[] states = new string[moduleNames.Length];
			for (int i = 0; i< states.Length; i++) {
				states [i] = UserInterfaceModule.ModuleStateToString (Program.getModuleByName (moduleNames [i]).state);
			}

			string s = "";
			for (int i = 0; i < states.Length; i++) {
				s += "[" + states [i] + "]  " + moduleNames [i] + "\n";
			}

			return s;
		}

		LazyMan lazy;
		ExitConfMenu exitConf;
	}
}
