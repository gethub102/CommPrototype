///////////////////////////////////////////////////////////////////
// PayloadWrapperTest.cs - Wrapper supports cloning, ToString()  //
// Ver 1.2                                                       //
// Application: Demonstration for CSE687-OOD, Project#2          //
// Language:    C#, ver 6.0, Visual Studio 2015                  //
// Platform:    Dell XPS2700, Core-i7, Windows 10                //
// Author:      Jim Fawcett, CST 4-187, Syracuse University      //
//              (315) 443-3948, jfawcett@twcny.rr.com            //
///////////////////////////////////////////////////////////////////
/*
 * Package Operations:
 * -------------------
 * This package provides tests for PayloadWrapper members:
 * Clone(), ToString(), ToXml(), Equals(...), and GetHashCode()
 */
/*
 * Maintenance:
 * ------------
 * Required Files: 
 *   PayloadWrapper, DBElement, DBEngine, DBExtensions.cs, 
 *   UtilityExtensions.cs
 *
 * Build Process:  devenv Project2Starter.sln /Rebuild debug
 *                 Run from Developer Command Prompt
 *                 To find: search for developer
 *
 * Maintenance History:
 * --------------------
 * ver 1.2 : 04 Oct 15
 * - minor modifications to accomodate refactoring of DBElement
 *   and DBExtensions.
 * ver 1.1 : 03 Oct 15
 * - moved functions ShowEquality(...), ShowDateTimeEquality(...)
 *   and ShowListEquality<T>(...) to UtilityExtensions.
 * ver 1.0 : 24 Sep 15
 * - first release
 *
 */
//ToDo: 2 - Test PayloadWrapper.Equals
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Project4Starter.Utilities;

namespace Project4Starter
{
  class TestPayLoadWrapper
  {
    static void Main(string[] args)
    {
      "Testing Payload Wrapper for stringt".title('=');
      WriteLine();

      PL_String pls = new PL_String();
      pls.theWrappedData = new StringBuilder("a test string");

      "Showing type of payload".title();
      Write("\n  type of payload is {0}", pls.typeName());
      WriteLine();

      "showing value of PL_String".title();
      Console.Write("\n  value = \"{0}\"", pls.theWrappedData);
      WriteLine();

      "output from PL_String.ToString()".title();
      Write("\n  \"{0}\"", pls.ToString());
      WriteLine();

      "output from PL_String.Clone()".title();
      PL_String clonedPls = pls.Clone() as PL_String;
      Write("\n  {0}", clonedPls.ToString());
      WriteLine();

      "modifying cloned PL_String".title();
      clonedPls.theWrappedData.Append(" modified");
      Write("\n  {0}", clonedPls.ToString());
      WriteLine();

      "the original is unchanged".title();
      Write("\n  {0}", pls.ToString());
      WriteLine();

      "showing output from PL_String.ToXml()".title();
      Write("  {0}", pls.ToXml());
      WriteLine();

      "output from elem.showElement<int, PL_String>()".title();
      DBElement<int, PL_String> selem = new DBElement<int, PL_String>();
      selem.name = "test element";
      selem.descr = "created to test PayloadWrapper for string";
      selem.payload = new PL_String("alpha beta");
      Write(selem.showElement<int, PL_String>());
      WriteLine();

      "Testing PayloadWrapper for List<string>".title('=');
      WriteLine();

      PL_ListOfStrings los = new PL_ListOfStrings();
      los.theWrappedData.AddRange(new List<string> { "one", "two", "three" });

      "showing List of strings:".title();
      foreach (string item in los.theWrappedData)
        Write("\n  {0}", item);
      WriteLine();

      "Output from PayloadWrapper.ToString()".title();
      Write("\n  {0}\n", los.ToString());

      "output from PayloadWraper Clone".title();
      PL_ListOfStrings clonedLos = los.Clone() as PL_ListOfStrings;
      Write("\n  {0}\n", clonedLos.ToString());

      "output from PayloadWrapper.ToXml()".title();
      Write("{0}", los.ToXml());
      WriteLine();

      "output from elem.showElement<string, PL_ListOfStrings>()".title();
      DBElement<string, PL_ListOfStrings> elem = new DBElement<string, PL_ListOfStrings>();
      elem.name = "test element";
      elem.descr = "created to test PayloadWrapper for List<string>";
      elem.payload = new PL_ListOfStrings();
      elem.payload.theWrappedData = new List<string> { "alpha", "beta", "gamma", "delta", "epsilon" };
      Write(elem.showElement<string, PL_ListOfStrings>());
      WriteLine();

      "test cloning elem".title('=');
      WriteLine();
      DBElement<string, PL_ListOfStrings> cloned = elem.Clone() as DBElement<string, PL_ListOfStrings>;

      "output from cloned.showElement<string, PL_ListOfStrings>()".title();
      Write(cloned.showElement<string, PL_ListOfStrings>());
      WriteLine();

      //"Hashcodes are not reliable object identifiers".title();
      //Write(string.Format("\n  hashcode of elem           = {0}", elem.GetHashCode()));
      //Write(string.Format("\n  hashcode of elem.name      = {0}", elem.name.GetHashCode()));
      //Write(string.Format("\n  hashcode of elem.descr     = {0}", elem.descr.GetHashCode()));
      //Write(string.Format("\n  hashcode of elem.payload   = {0}", elem.payload.GetHashCode()));
      //WriteLine();

      //Write(string.Format("\n  hashcode of cloned         = {0}", cloned.GetHashCode()));
      //Write(string.Format("\n  hashcode of cloned.name    = {0}", cloned.name.GetHashCode()));
      //Write(string.Format("\n  hashcode of cloned.descr   = {0}", cloned.descr.GetHashCode()));
      //Write(string.Format("\n  hashcode of cloned.payload = {0}", cloned.payload.GetHashCode()));
      //WriteLine();

      "testing for equality immediately after cloning".title();
      showEquality(cloned.name, elem.name, "cloned.name vs. elem.name");
      showEquality(cloned.descr, elem.descr, "cloned.descr vs. elem.descr");
      showDateTimeEquality(cloned.timeStamp, elem.timeStamp, "cloned.timeStamp vs. elem.timeStamp");
      showListEquality(cloned.children, elem.children, "cloned.children vs. elem.children");
      showListEquality<string>(cloned.payload.theWrappedData, elem.payload.theWrappedData, "cloned.payload vs. elem.payload");
      WriteLine();

      "modifying Clone's properties".title();
      WriteLine();
      cloned.name = cloned.name + " modified";
      cloned.descr = cloned.descr + " modified";
      cloned.timeStamp = DateTime.Today;
      cloned.children.AddRange(new List<string> { "key11", "key13" });
      cloned.payload.theWrappedData.AddRange(new List<string> { "zeta", "eta" });
      "output from elem.showElement<string, PL_ListOfStrings>()".title();
      Write(elem.showElement<string, PL_ListOfStrings>());
      WriteLine();

      "output from cloned.showElement<string, PL_ListOfStrings>()".title();
      Write(cloned.showElement<string, PL_ListOfStrings>());
      WriteLine();

      "Testing equality after modifying Clone's values".title();
      showEquality(cloned.name, elem.name, "cloned.name vs. elem.name");
      showEquality(cloned.descr, elem.descr, "cloned.descr vs. elem.descr");
      showDateTimeEquality(cloned.timeStamp, elem.timeStamp, "cloned.timeStamp vs. elem.timeStamp");
      showListEquality(cloned.children, elem.children, "cloned.children vs. elem.children");
      showListEquality<string>(cloned.payload.theWrappedData, elem.payload.theWrappedData, "cloned.payload vs. elem.payload");
      WriteLine();

      "Testing Persistance for PL_String".title();
      PL_String ps = new PL_String("a string");
      string xml = ps.ToXml();
      Write(xml);
      PL_String pSreconstructed = ps.FromXml(xml) as PL_String;
      Write("\n  {0}", pSreconstructed.theWrappedData);
      WriteLine();

      "Testing Persistance for PL_ListOfStrings".title();
      PL_ListOfStrings plos = new PL_ListOfStrings();
      plos.theWrappedData.AddRange(new List<string> { "one", "two" });
      xml = plos.ToXml();
      Write(xml);
      PL_ListOfStrings reconstructed = plos.FromXml(xml) as PL_ListOfStrings;
      foreach (string item in plos.theWrappedData)
        Write("\n  {0}", item);
      Write("\n\n");
    }
  }
}
