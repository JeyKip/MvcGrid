using System.Collections.Generic;
using MvcGrid.Test.Helpers;
using MvcGrid.Utilites;
using NUnit.Framework;

namespace MvcGrid.Test.Utilites
{
    [TestFixture]
    public class PropertyResolverTest
    {
        [Test]
        public void Resolve_ValueIsString_ValueInQuote()
        {
            string key = "valueIsString";
            string value = "stringValue";
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: '{1}'", key, value);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsEnum_ValueInQuoteInLowerCase()
        {
            string key = "valueIsEnum";
            GridDataType value = GridDataType.XmlString;
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: 'xmlstring'", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsBoolean_ValueInLowerCase()
        {
            string key = "valueIsBoolean";
            bool value = true;
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: true", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsBooleanList_JsonArrayInLowerCase()
        {
            string key = "boolList";
            List<bool> value = new List<bool>() { true, false, false };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: [true, false, false]", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsClass_StringRepresentationOfClassInFigureBracket()
        {
            string key = "valueIsClass";
            PersonInfo value = new PersonInfo()
            {
                LastName = "Melnikova",
                FirstName = "Tatyana",
                Age = 23
            };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: {{{1}}}", key, value);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsCharArray_ListOfValuesInQuote()
        {
            string key = "charArray";
            char[] value = new char[] { 'a', 'b', 'c' };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: ['a', 'b', 'c']", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsStringArray_ListOfValuesInQuote()
        {
            string key = "stringArray";
            string[] value = new string[] { "a", "b", "c" };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: ['a', 'b', 'c']", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsEnumArray_ListOfValuesInQuoteInLowerCase()
        {
            string key = "enumArray";
            GridDataType[] value = new GridDataType[] { GridDataType.Json, GridDataType.Xml };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: ['json', 'xml']", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsNotStringArray_ListOfValuesWithoutQuotes()
        {
            string key = "intArray";
            int[] value = new int[] { 1, 2, 3 };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: [1, 2, 3]", key);
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Resolve_ValueIsClassIenumerable_JsonArray()
        {
            string key = "list";
            List<PersonInfo> value = new List<PersonInfo>() 
            {
                new PersonInfo()
                {
                    LastName = "Melnikova",
                    FirstName = "Tatyana",
                    Age = 23
                },
                new PersonInfo()
                {
                    LastName = "Nosolenko",
                    FirstName = "Evgeniy",
                    Age = 24
                }
            };
            KeyValuePair<string, object> x = new KeyValuePair<string, object>(key, value);

            string expected = string.Format("{0}: [{{{1}}}, {{{2}}}]", key, value[0].ToString(), value[1].ToString());
            string actual = PropertyResolver.Resolve(x);

            Assert.AreEqual(expected, actual);
        }
    }
}