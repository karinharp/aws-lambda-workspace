using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace am
{
    
public class LambdaFunc {

    ILambdaContext m_ctx;
    LambdaArg      m_data;
	
    public string Handler(LambdaArg data, ILambdaContext context){
	m_ctx  = context;
	m_data = data;
	
	m_data.sw.Start();
	
	m_ctx.Log(String.Format("{0:D8} : Start Process", m_data.sw.ElapsedMilliseconds));	
	
	var result = Job(data, context);

	m_ctx.Log(String.Format("{0:D8} : Wait Async Method", m_data.sw.ElapsedMilliseconds));
	
	var ret = result.Result;
	
	m_ctx.Log(String.Format("{0:D8} : Complete Process", m_data.sw.ElapsedMilliseconds));

	return ret;
    }

    public static async Task<string> Job(LambdaArg data, ILambdaContext ctx){
	// write your work !
	var ret = await Task.Run(() => {
		System.Threading.Thread.Sleep(1);
		return "{\"ret\":\"OK\"}";
	    });
	return ret;	    
    }
    
}

public class LambdaArg
{
    /*==[ lambda args ]=====================================================================*/
    
    public string evt { get; set; } = "default";

    /*======================================================================================*/
    
    public uint timestamp {
	get {
	    var timespan = m_now - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	    return (uint)timespan.TotalSeconds;
	}
    }
    public Stopwatch sw { get { return m_sw; }}

    /*======================================================================================*/
    
    DateTime  m_now; 
    Stopwatch m_sw;
    
    public LambdaArg(){
	m_now = DateTime.UtcNow;
	m_sw  = new Stopwatch();	
    }
    
    /*======================================================================================*/        
}
}
