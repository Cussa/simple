﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicLibrary {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class DefaultConfigResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DefaultConfigResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BasicLibrary.DefaultConfigResource", typeof(DefaultConfigResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;basicLibrary&gt;
        ///  &lt;log4net&gt;
        ///    &lt;appender name=&quot;ConsoleAppender&quot; type=&quot;log4net.Appender.ColoredConsoleAppender&quot;&gt;
        ///      &lt;mapping&gt;
        ///        &lt;level value=&quot;ERROR&quot; /&gt;
        ///        &lt;foreColor value=&quot;Red, HighIntensity&quot; /&gt;
        ///      &lt;/mapping&gt;
        ///      &lt;mapping&gt;
        ///        &lt;level value=&quot;CRITICAL&quot; /&gt;
        ///        &lt;foreColor value=&quot;Red, HighIntensity&quot; /&gt;
        ///      &lt;/mapping&gt;
        ///      &lt;mapping&gt;
        ///        &lt;level value=&quot;INFO&quot; /&gt;
        ///        &lt;foreColor value=&quot;Blue, HighIntensity&quot; /&gt;
        ///      &lt;/mapping&gt;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BasicLibraryConfig {
            get {
                return ResourceManager.GetString("BasicLibraryConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;config&gt;&lt;/config&gt;.
        /// </summary>
        internal static string ConfigFilesConfig {
            get {
                return ResourceManager.GetString("ConfigFilesConfig", resourceCulture);
            }
        }
    }
}
