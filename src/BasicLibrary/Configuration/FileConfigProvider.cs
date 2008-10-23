﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using BasicLibrary.Common;
using System.IO;

namespace BasicLibrary.Configuration
{
    public class FileConfigProvider<T> : AutoLocalizationConfigProvider<T>
        where T : ConfigElement, new()
    {
        protected const string LOCALIZATION_TAG = "localized";
        protected const string COUNTRY_ATTRIBUTE = "for";

        protected SafeDictionary<string, string> ConfigFiles
        {
            get
            {
                try
                {
                    ConfigFilesConfig config = ConfigFilesConfig.Get();
                    return config.ConfigFiles;
                }
                catch (FileNotFoundException)
                {
                    return new SafeDictionary<string, string>();
                }
            }
        }

        private static FileConfigProvider<T> instance;
        public static FileConfigProvider<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FileConfigProvider<T>();
                }
                return instance;
            }
        }

        [LocalizationProviderIgnore]
        public T Get(string file, string location)
        {
            T config = new T();

            XmlElement docElement;

            try
            {
                docElement = FileContentCache.GetAsXmlElement(file);
            }
            catch (FileNotFoundException)
            {
                if (DefaultFileAttribute.ShouldThrowException<T>())
                {
                    throw;
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(config.DefaultXmlString);
                    docElement = doc.DocumentElement;
                }
            }
            
            
            config.LoadFromElement(docElement);

            foreach (XmlElement element in docElement.GetElementsByTagName(LOCALIZATION_TAG))
            {
                if (element.Attributes[COUNTRY_ATTRIBUTE] != null && string.Equals(element.Attributes[COUNTRY_ATTRIBUTE].Value, location, StringComparison.InvariantCultureIgnoreCase))
                {
                    config.LoadFromElement(element);
                }
            }

            config.Lock();

            return config;
        }

        [LocalizationProviderIgnore]
        public override T Get(string location)
        {
            string file;

            if (!Attribute.IsDefined(typeof(T), typeof(ConfigFilesIgnoreAttribute)))
            {
                file = ConfigFiles[typeof(T).FullName];
                if (file != null) return Get(file, location);
            }

            file = DefaultFileAttribute.GetDefaultFile<T>();
            if (file != null) return Get(file, location);

            throw new InvalidOperationException("Cannot load " + typeof(T).Name + " from file. Config file not specified.");
        }
    }
}