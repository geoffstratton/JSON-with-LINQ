Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
Imports System.Linq
 
Sub Main()
    Dim jsonURL As String = "http://mysafeinfo.com/api/data?list=englishmonarchs&format=json"
    Dim reader As StreamReader
    Dim errorMsg As String = Nothing
 
    Try
         Dim request As HttpWebRequest = CType(WebRequest.Create(jsonURL), HttpWebRequest)
         Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
         reader = New StreamReader(response.GetResponseStream())
         Dim jsonStr As String = reader.ReadToEnd()
 
         'Console.Writeline(jsonStr)
 
         printJSON(jsonStr)
 
    Catch ex As WebException
          errorMsg = "Download failed. The response from the server was: " +
                 CType(ex.Response, HttpWebResponse).StatusDescription
          Console.WriteLine("Error: " + errorMsg)
    End Try
End Sub
 
Private Sub printJSON(jsonStr As String)
     ' Deserialize our JSON string, then filter and print it
 
     ' Json.NET deserializer gives you a list of .NET objects
     Dim monarchs = JsonConvert.DeserializeObject(Of List(Of JSON_data))(jsonStr)
 
     ' Iterate over the objects and print each name property
     For Each monarch In monarchs
           Console.Writeline(monarch.nm)
     Next
 
     ' Set up a LINQ statement to filter the monarchs list
     Dim monarchList = From monarch In monarchs Where monarch.nm.Contains("William") Select monarch
 
     ' Print the results of our LINQ query
     For Each monarch In monarchList
           Console.Writeline("King or Queen: " + monarch.nm + ", Years: " + monarch.yrs)
     Next
End Sub
 
Public Class JSON_data
    Public nm As String
    Public cty As String
    Public hse As String
    Public yrs As String
End Class