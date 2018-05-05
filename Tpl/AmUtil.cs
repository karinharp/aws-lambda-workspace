using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO;

namespace am
{
    public static class AmUtil {
	
	public static void Log(string msg,
			       [CallerFilePath] string file = "",
			       [CallerLineNumber] int line = 0,
			       [CallerMemberName] string member = ""
			       ){
	    var s = string.Format("[ {0}:{1} - {2} ] {3}\n", Path.GetFileName(file), line, member, msg);
	    Console.Write(s); 
	}
	
    }
}
