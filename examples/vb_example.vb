Imports System.IO
Imports System.Net

Module Module1

    Private Const Username As String = "aa580e768465da258943e-zone-custom"
    Private Const Password As String = "aa580e768465da258943e"
    Private Const MANGOPROXY_DNS As String = "http://43.153.237.55:2334"
    Private Const UrlToGet As String = "http://ip-api.com/json"

    Sub Main()
        Dim httpWebRequest = CType(WebRequest.Create(UrlToGet), HttpWebRequest)
        Dim webProxy = New WebProxy(New Uri(MANGOPROXY_DNS)) With {
                .Credentials = New NetworkCredential(Username, Password)
                }
        httpWebRequest.Proxy = webProxy
        Dim httpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
        Dim responseStream = httpWebResponse.GetResponseStream()

        If responseStream Is Nothing Then
            Return
        End If

        Dim responseString = New StreamReader(responseStream).ReadToEnd()
        Console.WriteLine($"Response:{Environment.NewLine}{responseString}")
        Console.ReadKey()
    End Sub

End Module
