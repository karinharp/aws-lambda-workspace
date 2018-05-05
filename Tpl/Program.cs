using System;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.Core;

namespace am {
    class Program {
        static void Main(string[] args){
	    var lambdaFunc = new LambdaFunc();
	    var sampleArg  = new LambdaArg(){
	    };
	    
            var ret = lambdaFunc.Handler(sampleArg, new TestLambdaContext());
	    Console.WriteLine("Ret > " +  ret);
        }
    }
}
