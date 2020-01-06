// Learn more about F# at http://fsharp.net
module Sofa.Net

open System
open System.Text
open System.IO
open System.Net

//%%usare la WebUtility.HtmlDecode ??

/// WEB PROXY PER HTTP CONNECTION
/// es: let webproxy = proxy_conn("http://10.1.1.50:8080", "group", "user", "pwd")
let proxy_conn(pserver,pdomain,puser,ppwd) =
    let uriproxy = new Uri(pserver)
    let credproxy = new NetworkCredential()
    credproxy.Domain <- pdomain
    credproxy.UserName <- puser
    credproxy.Password <- ppwd
    let webproxy = new WebProxy()
    webproxy.Credentials <- credproxy
    webproxy.Address <- uriproxy
    webproxy

/// HTTP GET CON PROXY (vedi proxy_conn)
/// es: let google = http_get_p("http://www.google.com", webproxy)
let http_get_p(url:string, webproxy) =
    let req = WebRequest.Create(url)
    req.Proxy <- webproxy
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

/// HTTP GET
let http_get(url:string) = http_get_p(url, null)

/// HTTP POST CON PROXY (vedi proxy_conn)
let http_post_p (url:string, data:string, webproxy) =
    let postBytes = Encoding.ASCII.GetBytes(data)
    let req = WebRequest.Create(url) 
    req.Proxy <- webproxy
    req.Method <- "POST"
    req.ContentType <- "application/x-www-form-urlencoded"
    req.ContentLength <- int64 postBytes.Length
    let reqStream = req.GetRequestStream() 
    reqStream.Write(postBytes, 0, postBytes.Length);
    reqStream.Close()
    let resp = req.GetResponse() 
    let stream = resp.GetResponseStream() 
    let reader = new StreamReader(stream) 
    let html = reader.ReadToEnd()
    resp.Close()
    html

/// HTTP POST
let http_post(url:string, data:string) = http_post_p(url, data, null)

/// HTTP GET FILE CON PROXY (vedi proxy_conn)
/// es: let google = http_get_file_p("http://www.google.com", @"c:\res.txt", webproxy)
let http_get_file_p(url:string, file:string,  webproxy) =
    let webclient = new WebClient()
    webclient.Proxy <- webproxy
    webclient.DownloadFile(url, file)

/// HTTP GET FILE
let http_get_file(url:string, file:string) = http_get_file_p(url, file, null)