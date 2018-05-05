<?php

if($argc < 3){ echo "Invalid Args."; exit(); }

$conf = "aws-lambda-tools-defaults.json";

$funcName = $argv[1];
$roleArn  = $argv[2];

$coreVersion = "2.0";
//$coreVersion = "1.0";

$def = array (
    "profile"              =>  "default",
    "region"               =>  "ap-northeast-1",
    "configuration"        =>  "Release",
    "framework"            =>  "netcoreapp" . $coreVersion,
    "function-runtime"     =>  "dotnetcore" . $coreVersion,
    "function-memory-size" =>  256,
    "function-timeout"     =>  30,
    "function-handler"     =>  $funcName . "::am.LambdaFunc::Handler",
    "function-name"        =>  $funcName,
    "function-role"        =>  $roleArn   
);

//echo "\n" . json_encode($def, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES) . " \n\n";
file_put_contents($conf, json_encode($def, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES));

echo "generate " . $conf . "\n";