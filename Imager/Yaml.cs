/*
Yaml.cs is part of the Imager.
Copyright (c) 2021 Li Alex Zhang and Contributors

Permission is hereby granted, free of charge, to any person obtaining a 
copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation
the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the 
Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included 
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF 
OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace Imager
{
    public static class Yaml
    {
        static ISerializer serializer;
        static IDeserializer deserializer;

        static Yaml()
        {
            serializer = new SerializerBuilder().DisableAliases().IgnoreFields().Build();
            deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().IgnoreFields().Build();
        }

        public static void WriteYamlFile<T>(this string path, T data)
        {
            File.WriteAllText(path, data.SerializeYaml());
        }

        public static string SerializeYaml<T>(this T data)
        {
            return serializer.Serialize(data);
        }

        public static T ReadYamlFile<T>(this string path)
        {
            return File.ReadAllText(path).DeserializeYaml<T>();
        }

        public static T DeserializeYaml<T>(this string data)
        {
            return deserializer.Deserialize<T>(data);
        }
    }
}