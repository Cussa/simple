﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;
using SimpleLibrary.ServiceModel;
using SimpleLibrary.Config;
using BasicLibrary.Logging;

namespace SimpleLibrary.Rules
{
    public static class RulesFactory
    {
        private static Dictionary<Type, object> ProviderCache = new Dictionary<Type, object>();
        private static SimpleLibraryConfig Config = SimpleLibraryConfig.Get();

        public static T Create<T>() where T : class
        {
            IRulesProvider<T> provider = null;

            if (ProviderCache.ContainsKey(typeof(T)))
            {
                provider = (IRulesProvider<T>)ProviderCache[typeof(T)];
            }
            else
            {
                foreach (string typeString in Config.Business.RulesFactories)
                {
                    try
                    {
                        Type type = Type.GetType(typeString);
                        provider = (IRulesProvider<T>)Activator.CreateInstance(type.MakeGenericType(typeof(T)));
                        break;
                    }
                    catch (Exception e)
                    {
                        MainLogger.Default.Warn("Couldn't load provider type " + typeString, e);
                    }
                }

                if (provider == null)
                {
                    provider = new ServiceRulesProvider<T>();
                }

                ProviderCache[typeof(T)] = provider;
            }

            return provider.Create();
        }
    }
}
