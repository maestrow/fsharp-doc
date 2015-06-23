#load @"packages/FSharp.Formatting.2.9.9/FSharp.Formatting.fsx"
open FSharp.Literate
open System.IO

let currentDir = __SOURCE_DIRECTORY__
let tpl = "../tpl"
let src = "../src"
let out = "../doc"
let template = Path.Combine(currentDir, tpl, "template.html")

let compile fileName =
  let sourceFile = Path.Combine(currentDir, src, fileName)
  let outFile = Path.Combine(currentDir, out, fileName + ".html")
  Literate.ProcessScriptFile(sourceFile, template, outFile)

compile "FSharp Cheat Sheet.fsx"