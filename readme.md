#Syntactic Sugar for .NET

A collection of .NET helper classes, extension methods and shortcuts for common .NET operations.

The project is divided in several class libraries:

- Sugar: Core of the nice to have helpers and extensions methods.
- Sugar.Html: Extension methods geared towards parsing HTML (dependency on HtmlAgilityPack).
- Sugar.Test: Unit tests (nunit + moq)
- Sugar.Test.Integration: Integration test

##Overview

###Array Extensions

- `Slice`: Returns a subset of an array

###Assembly Extensions

- `GetTypes`: Returns all the types in the given assembly under the specifed namespace

###Bitmap Extensions

- `GetMaximumSizeOfImage`: Gets the maximum size of a an image
- `CreateBitmap`: Converts an Image into a Bitmap instance
- `ResizeImage`: Reizses a image to the given dimensions (returns a Bitmap)
- `CropImage`: Crops an image to the given dimensions (returns a Bitmap)
- `ToBytes`: Converts an image to a Bitmap and returns a byte array (in the specified image format)
- `GetMimeType`: Works out the mime type of a specified Bitmap image instace
- `GetImageFormatFromMimeType`: Converts an image mime type to an ImageFormat enum value.
 
###Collection Extensions

- `AddIfNotExists`: Adds an item to the specified list if it is not already contained in the list
- `GetMaximumIndexUsingFilter`: Gets the maximum index of the item in a list that matches the given filter
- `GetIndexUsingFilter`: Gets the index of the first item in the list that matches the given filter
- `RemoveAndInsertAt`: Swaps the items at the specified indices
- `RemoveIf`: Removes an item from the collection if a predicate evaluates to true

###Command

- Base classes, interface and attributes to kick start a command line application

###CountryCode

- Enumeration listing all countries on Earth (ISO 3166-1-alpha-2 code elements) 

###DateTime Extensions

- Parsing of date time strings
- Offseting a date by an time span offset
- Converting to and from ISO 8601 formatted values
- Output date time to human readable values (e.g. An hour ago...)
- Get the last day of week or month for given a given value

###Dictionary Extensions

- `GetKeysFromValue`: Returns the keys containing the given value
- `PairedWith`: Returns a KeyValuePair from a string and given value

### Double Exntensions

- Parsing and formating of doubles.

###Enumerable Extensions

- `Each`: executes the given action for on each element of an IEnumerable
- `ToCsv`: naive extensions converting all the value of the IEnumerable to a CSV value (e.g. one,two,three)
- `FromCsv`: naive extensions converting CSV values to an IEnumerable
- `Distinct`: shorcuts to remove duplicates in an IEnumerable (string, int, double...)
- `Reindex`: reindexes the specified collection, using the given index as the first element.  Items before the index are appended to the end
- `Strip`:  removes a value from an IEnumerable
- `StripNullOrWhitespace`: removes empty values from an IEnumerable of string values
- `Trim`: trims all the values in an IEnumerable of string values
- `WildcardSearch`: performs a wildcard search inside an IEnumerable of string values

###Enum Extensions

- Helpers to work with flaggable enumerations.

###File Service

- Wraps System.IO.File behind an interface to ease unit testing

###GeoLocation

Represents a point on the surface of a sphere approximating the Earth

###HtmlBuilder

- IBuilder implementation to help generating HTML fragments.

###Http Service

- Wraps calls to .NET's HttpWebResponse with an interface that is easily mockable in a unit test

### Int32 Extensions

- Parsing int values

###Object Extensions

- Object extension method to help dumping instance values to text.

###Retry

- Helper class to retry a given action x times.

###String Extensions

- String extensions methods to help with string manipulations and parsing.

###TextTable

- Helper class to ouput text as a table in a console application

###TimeSpan Extensions

- `ToReadableString`: Outputs a TimeSpan as human readable string (e.g. Two hours, Less than a second...)

###Type Extensions

- `ToGenericFullName`: Gets the Namespace and Name of this type, including any generic parameters
- `HasAttribute`: Determines whether the type has a given attribute

###WebString Extensions

- HTML encoding and decoding shortcuts.

###XPathDocument Extensions

- Shortcuts to make XPath less painful in .NET.

##License

This project is licensed under the terms of the [MIT license](https://github.com/comsechq/sugar/blob/master/LICENSE.txt). 

By submitting a pull request for this project, you agree to license your contribution under the MIT license to this project.
