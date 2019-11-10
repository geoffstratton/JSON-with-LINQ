# JSON with LINQ
 VB.<span></span>NET console application demonstrating JSON with LINQ

A console application that downloads and processes JSON data using .NET 4.0 with the Newtonsoft Json.<span></span>NET library. The sample data is a list of kings and queens of England and the UK from http://mysafeinfo.com/api/data?list=englishmonarchs&format=json. This example then uses simple LINQ but the [Newstonsoft LINQ to JSON API](https://www.newtonsoft.com/json/help/html/LINQtoJSON.htm) may be more efficient.

Mysafeinfo.com returns its data as a list of JSON objects -- [{}, {}, {}] -- so on line 32 we tell the DeserializeObject() method that the objects to deserialize are embedded within another data type.