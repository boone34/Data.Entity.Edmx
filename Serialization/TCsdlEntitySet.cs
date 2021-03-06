// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 5.2.97.0. www.xsd2code.com
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace TechNoir.Data.Entity.Edmx.Serialization
{
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
[Serializable]
[DebuggerStepThrough]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[XmlTypeAttribute(Namespace="http://schemas.microsoft.com/ado/2009/11/edm")]
public partial class TCsdlEntitySet
{
    private static XmlSerializer _serializer;
        [XmlAnyElementAttribute()]
        [XmlElement("Documentation", typeof(TCsdlDocumentation))]
        [XmlElement("TypeAnnotation", typeof(TTypeAnnotation))]
        [XmlElement("ValueAnnotation", typeof(TValueAnnotation))]
        public List<object> Items { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string EntityType { get; set; }
        [XmlAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, Namespace="http://schemas.microsoft.com/ado/2006/04/codegeneration")]
        public TAccess GetterAccess { get; set; }
        [XmlAnyAttributeAttribute()]
        public List<System.Xml.XmlAttribute> AnyAttr { get; set; }
    
    public TCsdlEntitySet()
    {
        AnyAttr = new List<System.Xml.XmlAttribute>();
        Items = new List<object>();
    }
    
    private static XmlSerializer SerializerXML
    {
        get
        {
            if ((_serializer == null))
            {
                _serializer = new XmlSerializerFactory().CreateSerializer(typeof(TCsdlEntitySet));
            }
            return _serializer;
        }
    }
    
    #region Serialize/Deserialize
    /// <summary>
    /// Serialize TCsdlEntitySet object
    /// </summary>
    /// <returns>XML value</returns>
    public virtual string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            System.Xml.XmlWriterSettings xmlWriterSettings = new System.Xml.XmlWriterSettings();
            System.Xml.XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
            SerializerXML.Serialize(xmlWriter, this);
            memoryStream.Seek(0, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            if ((streamReader != null))
            {
                streamReader.Dispose();
            }
            if ((memoryStream != null))
            {
                memoryStream.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes TCsdlEntitySet object
    /// </summary>
    /// <param name="input">string workflow markup to deserialize</param>
    /// <param name="obj">Output TCsdlEntitySet object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool Deserialize(string input, out TCsdlEntitySet obj, out Exception exception)
    {
        exception = null;
        obj = default(TCsdlEntitySet);
        try
        {
            obj = Deserialize(input);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool Deserialize(string input, out TCsdlEntitySet obj)
    {
        Exception exception = null;
        return Deserialize(input, out obj, out exception);
    }
    
    public static TCsdlEntitySet Deserialize(string input)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(input);
            return ((TCsdlEntitySet)(SerializerXML.Deserialize(XmlReader.Create(stringReader))));
        }
        finally
        {
            if ((stringReader != null))
            {
                stringReader.Dispose();
            }
        }
    }
    
    public static TCsdlEntitySet Deserialize(Stream s)
    {
        return ((TCsdlEntitySet)(SerializerXML.Deserialize(s)));
    }
    #endregion
    
    /// <summary>
    /// Serializes current TCsdlEntitySet object into file
    /// </summary>
    /// <param name="fileName">full path of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool SaveToFile(string fileName, out Exception exception)
    {
        exception = null;
        try
        {
            SaveToFile(fileName);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }
    
    public virtual void SaveToFile(string fileName)
    {
        StreamWriter streamWriter = null;
        try
        {
            string dataString = Serialize();
            FileInfo outputFile = new FileInfo(fileName);
            streamWriter = outputFile.CreateText();
            streamWriter.WriteLine(dataString);
            streamWriter.Close();
        }
        finally
        {
            if ((streamWriter != null))
            {
                streamWriter.Dispose();
            }
        }
    }
    
    /// <summary>
    /// Deserializes xml markup from file into an TCsdlEntitySet object
    /// </summary>
    /// <param name="fileName">string xml file to load and deserialize</param>
    /// <param name="obj">Output TCsdlEntitySet object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this Serializer can deserialize the object; otherwise, false</returns>
    public static bool LoadFromFile(string fileName, out TCsdlEntitySet obj, out Exception exception)
    {
        exception = null;
        obj = default(TCsdlEntitySet);
        try
        {
            obj = LoadFromFile(fileName);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }
    
    public static bool LoadFromFile(string fileName, out TCsdlEntitySet obj)
    {
        Exception exception = null;
        return LoadFromFile(fileName, out obj, out exception);
    }
    
    public static TCsdlEntitySet LoadFromFile(string fileName)
    {
        FileStream file = null;
        StreamReader sr = null;
        try
        {
            file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(file);
            string dataString = sr.ReadToEnd();
            sr.Close();
            file.Close();
            return Deserialize(dataString);
        }
        finally
        {
            if ((file != null))
            {
                file.Dispose();
            }
            if ((sr != null))
            {
                sr.Dispose();
            }
        }
    }
}
}
#pragma warning restore
