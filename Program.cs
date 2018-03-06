using System;

namespace GP_Midterm_BubblePuzzle {
#if WINDOWS || LINUX
	public static class Program {
		[STAThread]
		static void Main() {
			using (var game = new Main())
				game.Run();
		}
	}
#endif
}
